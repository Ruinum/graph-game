using Ruinum.ECS.Core.Systems.Log;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Texts
{
    public sealed class ConsoleLogEntityStrategy : EntityStrategy
    {
        public ITextStrategy Text = new SimpleStringTextStrategy();
        public LogType LogType = LogType.Error;
        
        public override bool Process(GameEntity entity)
        {
            if (!Text.TryGet(entity, out var text))
            {
                if(Logging) LogErrorNotFound(nameof(text), (nameof(entity), entity));
                return false;
            }
            LogExtention.Log(text);
            return true;
        }
    }
}