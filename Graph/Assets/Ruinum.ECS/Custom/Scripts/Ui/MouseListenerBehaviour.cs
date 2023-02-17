using Ruinum.ECS.Configurations.Game;
using UnityEngine;

namespace Ruinum.ECS.Scripts.Entities.Components.Game
{
    public class MouseListenerBehaviour : GameEntityComponentBehaviour
    {
        [SerializeField] private GameEntityConfig _onClickConfig;
        [SerializeField] private GameEntityConfig _onEnterConfig;

        private GameEntity _onEnterEntity;

        private void OnMouseDown()
        {
            _onClickConfig.Create(Entity);
        }

        private void OnMouseEnter()
        {
            _onEnterEntity = _onEnterConfig.Create(Entity);
        }

        private void OnMouseExit() 
        {
            if (_onEnterEntity != null) _onEnterEntity.Destroy();   
        }
    }
}