using Ruinum.ECS.Scripts.Entities.Components.Game;

namespace Ruinum.ECS.Scripts.UI
{
    public sealed class RootCanvasBehaviour : GameEntityComponentBehaviour //, IAnyRootCanvasChildListener
    {
        private GameEntity _listenerEntity;

        protected override void OnSetEntity(GameEntity entity)
        {
            _listenerEntity = Contexts.sharedInstance.game.CreateEntity();
            //_listenerEntity.AddAnyRootCanvasChildListener(this);
        }

        protected override void OnEntityDestroyed()
        {
            //_listenerEntity.RemoveAnyRootCanvasChildListener(this);
            _listenerEntity.isDestroyed = true;
        }

        public void OnAnyRootCanvasChild(GameEntity entity)
        {
            entity.gameObject.Value.transform.SetParent(transform, false);
            entity.gameObject.Value.transform.SetAsFirstSibling();
        }
    }
}