using System;
using Entitas;

using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Editor.ComponentDrawer;
using Ruinum.ECS.Core.Extensions.Native;

using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;

using UnityEditor;

namespace Ruinum.Editor.ComponentDrawer
{
    public sealed class EntityStrategyComponentDrawer : IConfigComponentDrawer
    {
        public bool HandlesType(Type type)
        {
            return type.IsSubclassOf(typeof(EntityStrategyComponentBase));
        }

        public IComponent DrawComponent(IComponent component, IEntity entity)
        {
            var strategyComponent = (EntityStrategyComponentBase) component;
            EditorGUILayout.BeginHorizontal();
            switch (strategyComponent.Strategy)
            {
                case UnityEngine.Object strategyObject:
                    strategyComponent.Strategy =
                        (IEntityStrategy) EditorGUILayout.ObjectField(strategyComponent.Strategy == null ? null : strategyObject, typeof(EntityStrategyConfig), false);
                    break;
                case null:
                    strategyComponent.Strategy = (IEntityStrategy) EditorGUILayout.ObjectField(null, typeof(EntityStrategyConfig), false);
                    break;
                default:
                    EditorGUILayout.LabelField(strategyComponent.Strategy.GetTypeName());
                    break;
            }
            if (SirenixEditorGUI.IconButton(EditorIcons.Pen))
            {
                OdinEditorWindow.InspectObject(strategyComponent);
            }
            if (SirenixEditorGUI.IconButton(EditorIcons.X))
            {
                strategyComponent.Strategy = null;
            }
            EditorGUILayout.EndHorizontal();
            return component;
        }
    }
}