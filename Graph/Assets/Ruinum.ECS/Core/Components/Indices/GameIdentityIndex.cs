using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ruinum.ECS.Components.Indices
{
    public sealed class GameIdentityIndex : PrimaryEntityIndex<GameEntity, (uint, int)>
    {
        public GameIdentityIndex(GameContext context) : base(Contexts.IdentityIndex,
            context.GetGroup(GameMatcher.ConfigIndex),
            (e, c) =>
            {
                var configIndexComponent = (ConfigIndexComponent)c;
                return (configIndexComponent.Value, configIndexComponent.EntityIdentity);
            })
        { 
        }



        [EntityIndexGetMethod]
        public GameEntity GetEntityWithIdentity(uint identity, int entityIdentity)
        {
            return GetEntity((identity, entityIdentity));
        }
    }
}