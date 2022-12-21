using System;
using System.Collections.Generic;
using System.Linq;

using Ruinum.ECS.Core.Extensions.Native;
using Ruinum.Editor;

using Sirenix.OdinInspector;

using UnityEngine;


namespace Ruinum.ECS.Editor.Configurations
{
    public abstract class ComponentInfoConfig : ScriptableObject, ISerializationCallbackReceiver
    {
        protected abstract string[] ComponentNames { get; }
        protected abstract Type[] ComponentTypes { get; }

        public abstract Type EntityType { get; }

        [ListDrawerSettings(HideAddButton = true, HideRemoveButton = true)]
        public List<ComponentInfo> Infos = new List<ComponentInfo>();

        public string GetInfo(int index)
        {
            var componentName = ComponentNames[index];
            return Infos.FirstOrDefault(m => m.Name.Equals(componentName))?.Info ?? string.Empty;
        }

        public void OnBeforeSerialize()
        {

        }

        public void OnAfterDeserialize()
        {
            for (int i = Infos.Count - 1; i >= 0; i--)
            {
                if (!Enumerable.Contains(ComponentNames, Infos[i].Name))
                {
                    Infos.RemoveAt(i);
                }
            }
            for (int i = 0, max = ComponentNames.Length; i < max; i++)
            {
                var componentName = ComponentNames[i];
                if (IsEditorComponent(componentName) && !IsComponentInfo(componentName))
                {
                    Infos.Add(new ComponentInfo(componentName));
                }
                else if (!IsEditorComponent(componentName) && IsComponentInfo(componentName))
                {
                    Infos.RemoveAll(m => m.Name.Equals(componentName));
                }
            }
        }

        private bool IsComponentInfo(string componentName)
        {
            return Infos.Exists(m => m.Name.Equals(componentName));
        }

        private bool IsEditorComponent(string componentName)
        {
            return ComponentTypes[ComponentNames.IndexOf(componentName)].HasEditorComponentAttribute();
        }
    }
}