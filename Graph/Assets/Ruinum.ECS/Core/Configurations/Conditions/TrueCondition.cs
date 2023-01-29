namespace Ruinum.ECS.Core.Conditions
{
    public class TrueCondition : EntityCondition
    {
        protected override bool IsTrue(GameEntity entity)
        {
            return true;
        }
    }
}