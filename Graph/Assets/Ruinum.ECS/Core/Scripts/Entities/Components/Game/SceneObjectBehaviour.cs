using Ruinum.ECS.Configurations.Game;

namespace Ruinum.ECS.Scripts.Entities.Components.Game
{
    public sealed class SceneObjectBehaviour : GameEntityComponentBehaviour
    {
        public GameEntityConfig EntityConfig;

        private void Start()
        {
            var createdEntity = EntityConfig.Create();
            createdEntity.AddGameObject(gameObject);
            GetComponent<GameEntityBehaviour>().SetEntity(createdEntity);
        }
    }
}