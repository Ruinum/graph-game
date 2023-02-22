using System;
using Entitas;
using Entitas.VisualDebugging.Unity.Editor;
using UnityEditor;

namespace Ruinum.ECS.Editor.ComponentDrawer
{
    public class EntityListComponentDrawer : IComponentDrawer
    {
        public bool HandlesType(Type type)
        {
            return typeof(EntityListComponent) == type;
        }

        public IComponent DrawComponent(IComponent component)
        {
            var list = ((EntityListComponent) component).Value;
            foreach (var gameEntity in list)
            {
                EditorGUILayout.LabelField(gameEntity.ToString());
            }
            return component;
        }
    }
}