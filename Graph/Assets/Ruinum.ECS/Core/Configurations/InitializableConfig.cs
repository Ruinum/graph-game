using Ruinum.ECS.Configurations.Game;
using Ruinum.ECS.Services.Interfaces;

using UnityEngine;

namespace Ruinum.ECS.Configurations
{
    public abstract class InitializableConfig : ScriptableObject, IContextInitializable
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