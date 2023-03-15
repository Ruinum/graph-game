using Ruinum.ECS.Configurations.Game;

namespace Ruinum.ECS.Scripts.Entities.Components.Game
{
    public sealed class CreateEntityNestedBehaviour : GameEntityComponentBehaviour
    {
        public GameEntityConfig EntityConfig;

        protected override void OnSetEntity(GameEntity entity)
        {
            EntityConfig.Create(entity);
        }
    }
}