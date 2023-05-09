using Ruinum.ECS.Services.Interfaces;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies
{
    public sealed class InputMouseVectorStrategy : VectorStrategy
    {
        public override bool TryGet(GameEntity entity, out Vector3 result)
        {
            IInputService Input = Contexts.sharedInstance.game.services.Instance.Input;

            result = new Vector3(Input.GetMouseAxisX(), -Input.GetMouseAxisY(), 0f);
            return true;
        }
    }
}