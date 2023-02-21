using Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Core.Utility.Native;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Movement
{
    public sealed class MovementEntityStrategy : EntityStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public VectorStrategy VectorStrategy;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public bool DivideByDeltaTime;

        public override bool Process(GameEntity entity)
        {
            if (!VectorStrategy.TryGet(entity, out var result))
            {
                if(Logging) LogErrorNotFound("Vector", (nameof(entity), entity));
                return false;
            }
            entity.ReplaceMovement(result / (DivideByDeltaTime ? MathUtility.ClampZero(Time.deltaTime) : 1));
            return true;
        }
    }
}