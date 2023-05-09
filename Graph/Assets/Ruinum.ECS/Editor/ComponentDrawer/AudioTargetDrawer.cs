using System;
using Entitas;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;

namespace Ruinum.ECS.Editor.ComponentDrawer
{
    public sealed class AudioTargetDrawer : IConfigComponentDrawer
    {
        public bool HandlesType(Type type)
        {
            return type == typeof(AudioTargetComponent);
        }

        public IComponent DrawComponent(IComponent component, IEntity entity)
        {
            var audioTargetComponent = (AudioTargetComponent)component;
            
            switch (audioTargetComponent.Target)
            {
                case UnityEngine.Object strategyObject:
                    audioTargetComponent.Target =
                        (ITargetStrategy)EditorGUILayout.ObjectField(audioTargetComponent.Target == null ? null : strategyObject, typeof(TargetStrategyConfig), false);
                    break;
                case null:
                    audioTargetComponent.Target = (ITargetStrategy)EditorGUILayout.ObjectField(null, typeof(TargetStrategyConfig), false);
                    break;
                default:
                    EditorGUILayout.LabelField(audioTargetComponent.Target.ToString());
                    break;
            }

            return component;
        }
    }
} 