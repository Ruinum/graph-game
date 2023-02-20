using Ruinum.ECS.Extensions;

namespace Ruinum.ECS.Systems.Game.Motions
{
    public sealed class TransformMovementSystem : GroupExecuteSystem<GameEntity>
    {
        public TransformMovementSystem(GameContext context) : base(context, GameMatcher.AllOf(GameMatcher.Movement, GameMatcher.Owner))
        {
        }

        protected override void Execute(GameEntity entity)
        {
            var owner = entity.RootOwnerEntity;
            owner.ReplaceTransformMoveVector(owner.GetTransformMoveVector() + entity.movement.Value); 
        }
    }
}