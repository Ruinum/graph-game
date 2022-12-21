using Ruinum.ECS.Configurations.Game;
using Ruinum.ECS.Services.Interfaces;

using System.Collections.Generic;


namespace Ruinum
{
    public static class ConfigInitializer
    {
        private static Contexts _contexts;
        private static IGameServices _services;
        private static HashSet<IContextInitializable> _initializableConfigs = new HashSet<IContextInitializable>();

        public static void Initialize(Contexts contexts, IGameServices services)
        {
            _contexts = contexts;
            _services = services;
            foreach (var m in _initializableConfigs)
            {
                m.Initialize(contexts, services);
            }
            _initializableConfigs = new HashSet<IContextInitializable>();
        }

        public static void ValidateConfig(IContextInitializable config)
        {
            if (_contexts == null)
            {
                _initializableConfigs.Add(config);
            }
            else
            {
                config.Initialize(_contexts, _services);
            }
        }
    }
}