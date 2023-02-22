using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Unity.VisualScripting;

using DesperateDevs.Utils;

using Ruinum.ECS.Configurations;
using Ruinum.ECS.Configurations.Game;
using Ruinum.ECS.Configurations.Game.Indexes;
using Ruinum.ECS.Core.Extensions.Unity;
using Ruinum.ECS.Services;

using TMPro;

using UnityEngine;

using Object = UnityEngine.Object;
using UnityEngine.AddressableAssets;
using Ruinum.ECS.Scripts.Entities.Components.Game;

namespace Ruinum.ECS.Editor.Validation
{
    public class ConfigTree
    {
        public Dictionary<object, List<(string path, object obj)>> Objects = new Dictionary<object, List<(string, object)>>();
        public List<(string path, object obj)> NullPath = new List<(string, object)>();

        private static readonly Type[] Types = { typeof(InitializableConfig), typeof(InitializableSerializedConfig)};

        public void Build()
        {
            Objects = new Dictionary<object, List<(string, object)>>();
            NullPath = new List<(string path, object obj)>();

            Validate(ConfigService.LoadConfigIndexEditor());
            var sharedConfig = ConfigService.LoadSharedConfigEditor();

            Validate(sharedConfig, sharedConfig, sharedConfig.name);
        }

        private void Validate(GameConfigIndex index)
        {
            foreach (var entityConfig in index.GetConfigs())
            {
                Validate(index, entityConfig, string.Empty);
            }
        }

        private void Validate(object parent, object obj, string objectPath)
        {
            if (!IsNull(obj) && obj.GetType().IsClass && IsProcessed(obj, parent, objectPath) || (obj is string str && string.IsNullOrEmpty(str)))
            {
                return;
            }
            if (IsNull(obj))
            {
                IsProcessed(obj, parent, objectPath);
                return;
            }
            objectPath = string.Empty;
            switch (obj)
            {
                case IList list:
                {
                    for (int i = 0, max = list.Count; i < max; i++)
                    {
                        Validate(obj, list[i], $"{objectPath}/Element({i})");
                    }
                    break;
                }
                case IDictionary dictionary:
                    var keyEnumerator = dictionary.Keys.GetEnumerator();
                    while (keyEnumerator.MoveNext())
                    {
                        Validate(obj, keyEnumerator.Current, $"{objectPath}/Dictionary[Key]");
                    }
                    var valueEnumerator = dictionary.Values.GetEnumerator();
                    while (valueEnumerator.MoveNext())
                    {
                        Validate(obj, valueEnumerator.Current, $"{objectPath}/Dictionary[Value]");
                    }
                    break;                
                case GameEntityConfig entityConfig:
                    Validate(entityConfig);
                    break;
                case Object unityObj when IsIgnoredObject(unityObj): return;
                case ScriptableObject scriptableObject:
                    ValidateMembers(scriptableObject, objectPath);
                    break;
                case AssetReference assetReference:
                    Validate(obj, assetReference.editorAsset, objectPath + assetReference.GetType().Name);
                    break;
                case Component gameObjectComponent:
                    if (gameObjectComponent is GameEntityComponentBehaviour)
                    {
                        ValidateMembers(gameObjectComponent, objectPath);
                        break;
                    }
                    if (gameObjectComponent is TMP_Text tmpText)
                    {
                        Validate(gameObjectComponent, tmpText.text, objectPath + "/tmpText/");
                        break;
                    }
                    break;
                case GameObject gameObject:
                    foreach (var component in gameObject.GetComponents(typeof(Component)))
                    {
                        Validate(gameObject, component, $"{objectPath}/{(component.IsNull() ? "null component" : component.name)}");
                    }
                    for (int i = 0; i < gameObject.transform.childCount; i++)
                    {
                        Validate(gameObject, gameObject.transform.GetChild(i).gameObject, $"{objectPath}{gameObject.name}/child {i}:{gameObject.name}");
                    }
                    break; 
                default:
                    ValidateMembers(obj, objectPath);
                    break;
            }
        }
      

        private void Validate(GameEntityConfig obj)
        {
            foreach (var componentIndex in obj.GetComponentIndexes())
            {
                Validate(obj, obj.GetComponent(componentIndex), GameComponentsLookup.componentNames[componentIndex] + "/");
            }

            var nestedValue = obj.GetType().GetField("Nested")?.GetValue(obj);
            if (nestedValue != null)
            {
                Validate(obj, nestedValue, "Nested/");
            } 
            
            var initializerValue = obj.GetType().GetField("Initializer")?.GetValue(obj);
            if (initializerValue != null)
            {
                Validate(obj, initializerValue, "Initializer/");
            }
        }

        private static bool IsIgnoredObject(Object obj)
        {
            return obj is RuntimeAnimatorController || obj is Material;
        }

        private void ValidateMembers(object obj, string objectPath)
        {
            var fields = GetSerializableMemberInfos(obj.GetType());
            foreach (var field in fields)
            {
                if(!(obj is Object) || !field.name.Equals("name"))
                {
                    Validate(obj, field.GetValue(obj), $"{objectPath}{(string.IsNullOrEmpty(objectPath) ? string.Empty : "/")}{obj.GetType().Name}/{field.name}");
                }
            }
        }

        private bool IsProcessed(object obj, object parent, string path)
        {
            if(parent is GameConfigIndex)
            {
                return false;
            }
            if (IsNull(obj))
            {
                if (!NullPath.Exists(m => !IsNull(m.obj) && m.obj.Equals(obj)))
                {
                    NullPath.Add((path, parent));
                }
                return true;
            }
            var contains = Objects.ContainsKey(obj);
            if (!contains)
            {
                Objects.Add(obj, new List<(string, object)>());
            }
            var list = Objects[obj];
            if (!list.Exists(m => m.obj.Equals(obj)))
            {
                list.Add((path, parent));
            }
            return contains;
        }

        private static bool IsNull(object obj)
        {
            return obj == null || obj.Equals(null);
        }

        public ScriptableObject GetConfig(object obj, ref string path)
        {
            while (true)
            {
                if (obj is ScriptableObject scriptableObject)
                {
                    return scriptableObject;
                }
                var (parentPath, parentObj) = Objects[obj].First();
                path = parentPath + "/" + path;
                obj = parentObj;
            }
        }

        public Dictionary<Type, List<Object>> GetUnused()
        {
            Build();
            var result = new Dictionary<Type, List<Object>>();
            for (int i = 0, max = Types.Length; i < max; i++)
            {
                foreach (var obj in GetUnused(Types[i]))
                {
                    var objType = (obj is InitializableConfig) ? typeof(InitializableConfig) : obj.GetType();
                    if (!result.TryGetValue(objType, out var list))
                    {
                        list = new List<Object>();
                        result[objType] = list;
                    }
                    list.Add(obj);
                }
            }
            return result;
        }

        private List<Object> GetUnused(Type type)
        {
            var result = new List<Object>();
            var allConfigs = AssetUtilities.GetAllAssets(type);
            foreach (var config in allConfigs)
            {
                if (!Objects.ContainsKey(config) || Objects[config].Count == 0)
                {
                    result.Add(config);
                }
            }
            return result;
        }
        
        private static List<PublicMemberInfo> GetSerializableMemberInfos(Type type)
        {
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var publicMemberInfoList = new List<PublicMemberInfo>(fields.Length + properties.Length);
            for (int index = 0; index < fields.Length; ++index)
            {
                publicMemberInfoList.Add(new PublicMemberInfo(fields[index]));
            }

            var serializedFields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            for (int index = 0; index < serializedFields.Length; ++index)
            {
                if (serializedFields[index].HasAttribute<SerializeField>())
                {
                    publicMemberInfoList.Add(new PublicMemberInfo(serializedFields[index]));
                }
            }
            
            for (int index = 0; index < properties.Length; ++index)
            {
                var info = properties[index];
                if (info.CanRead && info.CanWrite && info.GetIndexParameters().Length == 0 && !info.GetMethod.IsPrivate && !info.SetMethod.IsPrivate)
                {
                    publicMemberInfoList.Add(new PublicMemberInfo(info));
                }
            }
            return publicMemberInfoList;
        }
    }
}