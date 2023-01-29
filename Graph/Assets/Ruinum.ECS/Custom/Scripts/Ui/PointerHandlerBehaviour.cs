using Ruinum.ECS.Configurations.Game;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Ruinum.ECS.Scripts.Entities.Components.Game
{
    public class PointerHandlerBehaviour : GameEntityComponentBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField] private GameEntityConfig _onClickConfig; 
        [SerializeField] private GameEntityConfig _onEnterConfig;

        private GameEntity _onEnterEntity;

        public void OnPointerClick(PointerEventData eventData)
        {
            _onClickConfig.Create(Entity);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _onEnterEntity = _onEnterConfig.Create(Entity);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _onEnterEntity.Destroy();
        }
    }
}