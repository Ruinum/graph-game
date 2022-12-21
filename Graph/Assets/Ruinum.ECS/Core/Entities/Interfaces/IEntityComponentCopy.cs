using Entitas;

namespace Ruinum.ECS.Entity.Interfaces
{
    public interface IEntityComponentCopy
    {
        void CopyComponent(int componentIndex, IComponent fromComponent);
    }
}
