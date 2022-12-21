using System;
using Entitas;
using Ruinum.ECS.Editor.ComponentDrawer;
using UnityEditor;


namespace Ruinum.Editor.ComponentDrawer
{
    public sealed class TextComponentDrawer : IConfigComponentDrawer
    {
        public bool HandlesType(Type type)
        {
            return type == typeof(TextComponent);
        }

        public IComponent DrawComponent(IComponent component, IEntity entity)
        {
            var textComponent = (TextComponent)component;
            textComponent.Value = EditorGUILayout.TextArea(textComponent.Value);
            return textComponent;
        }
    }
} 