using System;
using System.Collections.Generic;
using System.Linq;
using Ruinum.ECS.Core.Extensions.Native;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations
{
    [Serializable]
    public class SerializableGameComponentsContainer : ISerializationCallbackReceiver
    {
        private static readonly ValueDropdownList<int> ContextComponentNamesList = GetComponentsDropdownList(GameComponentsLookup.componentNames);
        [SerializeField, HideInInspector] private List<string> _components = new List<string>();

        [NonSerialized, ShowInInspector][ValueDropdown(nameof(ContextComponentNamesList), IsUniqueList = true, ExcludeExistingValuesInList = true, SortDropdownItems = true)]
        public int[] ComponentIndexes = new int[0];

        public void OnBeforeSerialize()
        {
            if (ComponentIndexes == null)
            {
                return;
            }
            _components = new List<string>(ComponentIndexes.Select(m => GameComponentsLookup.componentNames[m]));
        }

        public void OnAfterDeserialize()
        {
            if (_components == null)
            {
                return;
            }
            _components = _components.Where(m => GameComponentsLookup.componentNames.IndexOf(m) > 0).ToList();
            ComponentIndexes = _components.Select(m => GameComponentsLookup.componentNames.IndexOf(m)).ToArray();
        }

        protected static ValueDropdownList<int> GetComponentsDropdownList(string[] componentNames)
        {
            var list = new ValueDropdownList<int>();
            for (int i = 0, max = componentNames.Length; i < max; i++)
            {
                list.Add(componentNames[i], i);
            }
            return list;
        }
    }
}