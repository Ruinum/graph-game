using Ruinum.ECS.Constants;
using Ruinum.ECS.Scripts.UI;
using Entitas;
using UnityEngine;

namespace Ruinum.ECS.Systems.Game
{
    public sealed class RootCanvasInitializeSystem : IInitializeSystem
    {
        public void Initialize()
        {
            var canvas = GameObject.FindGameObjectWithTag(UiConstants.RootCanvasTag).GetComponent<RootCanvasBehaviour>();
            var entity = Contexts.sharedInstance.game.CreateEntity();
            entity.AddGameObject(canvas.gameObject);
            canvas.SetEntity(entity);
        }
    }
}