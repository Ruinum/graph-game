using UnityEngine;

namespace Ruinum.ECS.Scripts.Entities.Components.Game
{
    public class NestedEntityInitializerBehaviour : GameEntityComponentBehaviour
    {
        [SerializeField] private GameEntityBehaviour[] _behaviours = new GameEntityBehaviour[0];

        public GameEntityBehaviour[] GetBehaviours() => _behaviours;

        protected override void OnSetEntity(GameEntity entity)
        {
            for (int i = _behaviours.Length - 1; i >= 0; i--)
            {
                _behaviours[i].SetEntity(Entity);
            }
        }
    }
}