using System;
using UnityEngine;

using Ruinum.ECS.Services.Interfaces;
using Ruinum.ECS.Constants;

namespace Ruinum.ECS.Configurations.Game
{
    [CreateAssetMenu(menuName = MenuName, fileName = FileName)]
    public sealed class GameEntityConfig : EntityConfig<GameEntity>
    {
        public const string MenuName = EditorConstants.GameMenuPath + FileName;
        public const string FileName = nameof(GameEntityConfig);

        public GameEntityConfig[] Nested = new GameEntityConfig[0];


        public override Type[] ComponentTypes => GameComponentsLookup.componentTypes;

        public override string[] ComponentNames => GameComponentsLookup.componentNames;

        protected override void OnInitialize(Contexts contexts, IGameServices services)
        {
            Context = contexts.game;
        }

        public GameEntity Create(GameEntity owner)
        {
            var entity = Context.CreateEntity();
            ProcessIndex(entity);
            entity.AddOwner(owner);
            Configure(entity);
            CreateNested(entity);
            return entity;
        }

        protected override void CreateNested(GameEntity entity)
        {
            for (int i = 0, max = Nested.Length; i < max; i++)
            {
                Nested[i].Create(entity);
            }
        }
    }
}