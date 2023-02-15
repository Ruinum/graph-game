using Ruinum.ECS.Configurations.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Ruinum.ECS.Scripts.Entities.Components.Game
{
    [RequireComponent(typeof(Button))]
    public class ButtonListenerBehaviour : GameEntityComponentBehaviour
    {
        [SerializeField] private GameEntityConfig _config;
        
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);                    
        }

        public void OnClick()
        {
            _config.Create(Entity);
        }
    }
}