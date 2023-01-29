using UnityEngine;

namespace Ruinum.ECS.Scripts.Entities.Components.Game
{
    [RequireComponent(typeof(GameEntityBehaviour), typeof(CharacterController))]
    public class CharacterControllerBehaviour : GameEntityComponentBehaviour
    {
        protected override void OnSetEntity(GameEntity entity)
        {
            entity.ReplaceCharacterController(GetComponent<CharacterController>());
        }

        protected override void OnEntityDestroyed()
        {
            Entity.RemoveCharacterController();
        }
    }
}