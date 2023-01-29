using System;
using Ruinum.ECS.Scripts.Entities.Components.Game;
using TMPro;
using UnityEngine;

namespace Ruinum.ECS.Scripts.UI
{
    public sealed class TMPTextFloatValueBehaviour : GameEntityComponentBehaviour, IFloatValueListener, ITextListener
    {
        private TMP_Text _text;

        protected override void OnSetEntity(GameEntity entity)
        {
            _text = GetComponent<TMP_Text>();

            entity.AddFloatValueListener(this);
            entity.AddTextListener(this);
        }

        public void OnFloatValue(GameEntity entity, float value)
        {
            _text.text = Math.Round(value, 2).ToString();
        }

        public void OnText(GameEntity entity, string value)
        {
            _text.text = value;
        }

        protected override void OnEntityDestroyed()
        {
            Entity.RemoveFloatValueListener(this);
            Entity.RemoveTextListener(this);
        }
    }
}