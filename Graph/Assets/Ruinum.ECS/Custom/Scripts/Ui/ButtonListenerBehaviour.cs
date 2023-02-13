using Ruinum.ECS.Configurations.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ruinum.ECS.Scripts.Entities.Components.Game
{
    [RequireComponent(typeof(Button))]
    public class ButtonListenerBehaviour : GameEntityComponentBehaviour
    {
        [SerializeField] private GameEntityConfig _config;
        private Button _button;
        protected override void OnSetEntity(GameEntity entity)
        {
            Debug.Log(entity);
            _button = GetComponent<Button>();
            _button.onClick.AddListener(() => _config.Create(entity)); 
        }       
    }
}