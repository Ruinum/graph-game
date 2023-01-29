using System;
using Entitas;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;

namespace Ruinum.ECS.Editor.ComponentDrawer
{
    public sealed class EntitySubscriberComponentDrawer : IConfigComponentDrawer
    {
        public bool HandlesType(Type type)
        {
            return type.IsSubclassOf(typeof(EntitySubscriberComponent));
        }

        public IComponent DrawComponent(IComponent component, IEntity entity)
        {
            var subComponent = (EntitySubscriberComponent)component;
            if (SirenixEditorGUI.IconButton(EditorIcons.Pen, SirenixGUIStyles.BoldLabel))
            {
                OdinEditorWindow.InspectObject(subComponent);
            }
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Strategy", SirenixGUIStyles.BoldLabel);
            EditorGUILayout.LabelField(subComponent.Strategy == null ? "empty" : subComponent.Strategy.GetType().Name);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Target", SirenixGUIStyles.BoldLabel);
            EditorGUILayout.LabelField(subComponent.Target == null ? "empty" : subComponent.Target.GetType().Name);
            EditorGUILayout.EndHorizontal();
            EditorGUI.EndDisabledGroup();
            return subComponent;
        }
    }
}