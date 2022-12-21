using System;
using System.Collections.Generic;
using System.Linq;

using Ruinum.ECS.Configurations;

using Sirenix.OdinInspector.Editor;

using UnityEngine;


namespace Ruinum.ECS.Editor.EntityStateGraph
{
    public class AddComponentSelector : OdinSelector<string>
    {
        private EntityConfig _entityConfig;
        private Action<EntityConfig, string> _onSelectionConfirmed;

        public AddComponentSelector()
        {
            SelectionConfirmed += OnSelectionConfirmed;
        }

        public void Show(List<string> list, EntityConfig entityConfig, Action<EntityConfig, string> onSelectionConfirmed)
        {
            _entityConfig = entityConfig;
            _onSelectionConfirmed = onSelectionConfirmed;
            SelectionTree.Selection.Clear();
            SelectionTree.MenuItems.Clear(); 
            SelectionTree.AddRange(list, m => m);
            SelectionTree.UpdateMenuTree();
            EnableSingleClickToSelect();
            ShowInPopup(new Vector2(Event.current.mousePosition.x, Event.current.mousePosition.y));
        }

        private void OnSelectionConfirmed(IEnumerable<string> obj)
        {
            _onSelectionConfirmed.Invoke(_entityConfig, obj.First());
        }

        protected override void BuildSelectionTree(OdinMenuTree tree)
        {

        }
    }
}