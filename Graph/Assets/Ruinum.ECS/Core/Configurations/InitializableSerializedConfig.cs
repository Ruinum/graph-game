using Ruinum.ECS.Configurations.Game;
using Ruinum.ECS.Services.Interfaces;

using Sirenix.OdinInspector;


namespace Ruinum.ECS.Configurations
{
    [ShowOdinSerializedPropertiesInInspector]
    public abstract class InitializableSerializedConfig : SerializedScriptableObject, IContextInitializable
    {
        private void OnEnable()
        {
            ConfigInitializer.ValidateConfig(this);
        }

        public void Initialize(Contexts contexts, IGameServices services)
        {
            OnInitialize(contexts, services);
        }

        protected virtual void OnInitialize(Contexts contexts, IGameServices services)
        {
        }
    }
}