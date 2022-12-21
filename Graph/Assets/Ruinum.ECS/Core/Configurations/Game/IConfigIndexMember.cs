namespace Ruinum.ECS.Configurations.Game.Indexes
{
    public interface IConfigIndexMember
    {
        int ConfigIndex { get; }

        void SetIndex(int index);
    }
}