using System.Collections.Generic;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All
{
    public sealed class ReplaceAnyTargetFromBufferStrategy : TargetAllStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public TargetStrategy Target;

        public override bool TryGet(GameEntity entity, List<GameEntity> buffer)
        {
            if (buffer.Count == 0)
            {
                if(Logging) LogErrorNotFound("GameEntity for buffer");
                return false;
            }

            if (!Target.TryGet(entity, out var target))
            {
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            target.ReplaceGameTarget(buffer[0]);
            return true;
        }
    }
}