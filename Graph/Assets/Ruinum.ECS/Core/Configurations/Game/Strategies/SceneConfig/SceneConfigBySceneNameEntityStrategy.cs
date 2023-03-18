using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Configurations.Game.Strategies.Texts;
using Ruinum.ECS.Core.Configurations;
using Ruinum.ECS.Core.Configurations.Game.Strategies;

using System.Linq;

namespace Ruinum.ECS.Core.Components
{
    public class SceneConfigBySceneNameEntityStrategy : ContextInitializable, ISceneConfigStrategy
    {
        public ITextStrategy SceneName;

        public bool TryGet(GameEntity entity, out SceneConfig result)
        {
            if (!SceneName.TryGet(entity, out var sceneName))
            {
                if (Logging) LogError(nameof(sceneName), (nameof(entity), entity));
                result = default;
                return false;
            }

            var sceneConfigName = Services.Config.SharedConfig.SceneNames.FirstOrDefault(m => m.Name.Equals(sceneName));
            if (sceneConfigName == null)
            {
                if (Logging) LogError("sceneConfig", (nameof(entity), entity), (nameof(SceneName), SceneName));
                result = default;
                return false;
            }
            result = sceneConfigName.Config;
            return true;
        }
    }
}