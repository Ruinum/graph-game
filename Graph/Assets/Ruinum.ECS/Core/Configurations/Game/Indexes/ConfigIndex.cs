using System;
using System.Collections.Generic;

using UnityEditor;
using UnityEngine;

using Ruinum.ECS.Core.Extensions.Unity;


namespace Ruinum.ECS.Configurations.Game.Indexes
{
    public abstract class ConfigIndex<T> : ScriptableObject, IConfigIndex<T>, ISerializationCallbackReceiver where T : ScriptableObject, IConfigIndexMember
    {
        [SerializeField] private T[] _configs = new T[0];

        public T GetConfig(int index)
        {
            if (index < 0 || index >= _configs.Length)
            {
                throw new IndexOutOfRangeException($"Index of config <{typeof(T).Name}> is out of range");
            }
            return _configs[index];
        }

        public void OnBeforeSerialize()
        {

        }

        public void OnAfterDeserialize()
        {
            DeserializeConfigs();
        }

        private void DeserializeConfigs()
        {
#if UNITY_EDITOR
            ValidateEditor(false);
#endif
            for (int i = 0, max = _configs.Length; i < max; i++)
            {
                _configs[i].SetIndex(i);
            }
        }

#if UNITY_EDITOR
        public void ValidateEditor(bool setDirty = true)
        {
            var list = new List<T>();
            for (int i = 0, max = _configs.Length; i < max; i++)
            {
                var config = _configs[i];
                if (!config.IsNull())
                {
                    list.Add(config);
                }
            }
            _configs = list.ToArray();
            if (setDirty)
            {
                EditorUtility.SetDirty(this);  
            }
        }
        
        public List<T> GetConfigs()
        {
            return new List<T>(_configs);
        }

        public void Validate(T config)
        {
            var index = Array.IndexOf(_configs, config);
            if (index == -1)
            {
                ArrayUtility.Add(ref _configs, config);
                index = _configs.Length - 1;
                config.SetIndex(index);
                EditorUtility.SetDirty(config);
                EditorUtility.SetDirty(this);
            }
            if (config.ConfigIndex != index)
            {
                config.SetIndex(Array.IndexOf(_configs, config));
                EditorUtility.SetDirty(config);
            }
        }
#endif
    }
}