using UnityEngine;
using UnityEngine.UI;

namespace Ruinum.ECS.Scripts.Entities.Components.Game
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteRendererBehaviour : GameEntityComponentBehaviour, IColorListener
    {
        private SpriteRenderer _sprite;

        public void OnColor(GameEntity entity, Color color)
        {
            _sprite.color= color;
        }

        protected override void OnSetEntity(GameEntity entity)
        {
            _sprite = GetComponent<SpriteRenderer>();
            entity.AddColorListener(this);
        }

        protected override void OnEntityDestroyed()
        {
            Entity.RemoveColorListener(this);
        }
    }
}