using System;
using Entitas;
using UnityEditor;


namespace Ruinum.ECS.Editor.ComponentDrawer
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