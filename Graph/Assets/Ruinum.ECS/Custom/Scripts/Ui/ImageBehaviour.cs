using Ruinum.ECS.Scripts.Entities.Components.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Ruinum.ECS.Scripts.UI
{
    public class ImageBehaviour : GameEntityComponentBehaviour, IColorListener, ISpriteListener
    {
        protected Image Image;

        protected sealed override void OnSetEntity(GameEntity entity)
        {
            Image = GetComponent<Image>();

            entity.AddColorListener(this);
            entity.AddSpriteListener(this);

            if (entity.hasSprite)
            {
                OnSprite(entity, entity.sprite.Value);
            }
            if (entity.hasColor)
            {
                OnColor(entity, entity.color.Color);
            }
            OnSetEntityThis(entity);
        }

        protected virtual void OnSetEntityThis(GameEntity entity)
        {

        }

        public void OnColor(GameEntity entity, Color value)
        {
            Image.color = value;
        }

        public void OnSprite(GameEntity entity, Sprite value)
        {
            Image.sprite = value;
        }

        protected sealed override void OnEntityDestroyed()
        {
            Entity.RemoveColorListener(this);
            Entity.RemoveSpriteListener(this);
            OnEntityDestroyedThis();
        }

        protected virtual void OnEntityDestroyedThis()
        {
        }
    }
}