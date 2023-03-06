using Ruinum.ECS.Extensions;
using System.Collections;
using UnityEngine;

namespace Ruinum.ECS.Scripts.Entities.Components.Game
{
    public class SubscribeOnGameEntityListBehaviour : GameEntityComponentBehaviour
    {
        [SerializeField] private GameEntityBehaviour[] _behaviours = new GameEntityBehaviour[0];

        protected override void OnSetEntity(GameEntity entity)
        {
            for (int i = _behaviours.Length - 1; i >= 0; i--)
            {
                if (_behaviours[i].Entity == null) { StartCoroutine(WaitOnSubscribe(i)); continue; }
                var target = _behaviours[i].Entity;
                var entityList = target.hasEntityList ? target.entityList : target.CreateGameEntityListComponent();
                entityList.Value.Add(Entity);
                target.ReplaceComponent(GameComponentsLookup.EntityList, entityList);
            }
        }

        public void OnDestroyed(GameEntity entity)
        {
            var target = entity.gameTarget.Value;
            if (!target.hasEntityList)
            {
                return;
            }
            var entityListComponent = target.entityList;
            entityListComponent.Value.Remove(entity);
            target.ReplaceEntityList(entityListComponent.Value);
        }

        protected override void OnEntityDestroyed()
        {
            for (int i = _behaviours.Length - 1; i >= 0; i--)
            {
                var target = _behaviours[i].Entity;
                var entityListComponent = target.entityList;
                entityListComponent.Value.Remove(Entity);
                target.ReplaceEntityList(entityListComponent.Value);
            }
        }

        private IEnumerator WaitOnSubscribe(int index)
        {
            yield return new WaitForEndOfFrame();
            var target = _behaviours[index].Entity;
            var entityList = target.hasEntityList ? target.entityList : target.CreateGameEntityListComponent();
            entityList.Value.Add(Entity);
            target.ReplaceComponent(GameComponentsLookup.EntityList, entityList);
        }
    }
}