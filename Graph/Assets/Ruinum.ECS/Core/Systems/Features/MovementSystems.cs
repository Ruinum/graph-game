using Ruinum.ECS.Core.Systems;
using Ruinum.ECS.Services.Interfaces;
using Ruinum.ECS.Systems.Game.Motions;

namespace Ruinum.ECS.Systems.Features
{
    public sealed class MovementSystems : Feature
    {
        public MovementSystems(Contexts contexts, IGameServices services)
        {
            Add(new AccelerationSystem(contexts.game));
            Add(new VelocityMinSystem(contexts.game));
            Add(new VelocityMaxSystem(contexts.game));
            Add(new MovementVelocitySystem(contexts.game));
            Add(new TransformSmoothRotationSystem(contexts.game));
            Add(new TransformInstantRotationSystem(contexts.game));

            Add(new TransformMovementSystem(contexts.game));
            Add(new CharacterControllerMoveSystem(contexts.game));
            Add(new TransformMoveSystem(contexts.game));

            Add(new TransformPositionToSystem(contexts.game));
            Add(new TransformRotationToSystem(contexts.game));

            Add(new RemoveTransformMoveVectorSystem(contexts.game));
        }
    }
}