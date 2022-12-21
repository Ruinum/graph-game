using System;
using Entitas;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    public sealed class ControlledPlayerTargetStrategy : TargetStrategy
    {
        [NonSerialized] private IGroup<GameEntity> _group;
    
        protected override void OnInitialize()
        {
            base.OnInitialize();
            //_group = Contexts.game.GetGroup(GameMatcher.ControlledByPlayer);
        }

        public override bool TryGet(GameEntity entity, out GameEntity targetEntity)
        {
            if (_group.count == 0)
            {
                targetEntity = default;
                if(Logging) LogErrorNotFound("ControlledByPlayerComponent", (nameof(entity), entity));
                return false;
            }

            targetEntity = _group.GetSingleEntity();
            return true;
        } 
    }
}