using UnityEngine;

namespace Ruinum.ECS.Systems.Game.Motions
{
    public sealed class TransformSmoothRotationSystem : GroupExecuteSystem<GameEntity>
    {
        public TransformSmoothRotationSystem(GameContext context) : base(context, GameMatcher.AllOf(GameMatcher.SmoothRotation, GameMatcher.Rotation, GameMatcher.RootOwner))
        {
        }

        protected override void Execute(GameEntity entity)
        {
            var owner = entity.RootOwnerEntity;
            if (!owner.hasTransformRotation)
            {
                return;
            }
            owner.ReplaceTransformRotationTo(Quaternion.RotateTowards(
                owner.transformRotation.Value,
                entity.rotation.Value,
                (entity.hasSmoothRotationSpeed ? entity.smoothRotationSpeed.Value : 1) * Time.deltaTime));
        }
    }
}