using Ruinum.ECS.Configurations.Game;
using Ruinum.ECS.Configurations.Game.Strategies;
namespace Ruinum.ECS.Core.Configurations.Game.Strategies
{
    public interface IEntityConfigStrategy : IContextInitializable, IComponentStrategy<GameEntityConfig>
    {
    }
}