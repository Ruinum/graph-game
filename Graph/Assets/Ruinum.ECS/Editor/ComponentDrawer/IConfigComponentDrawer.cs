using System;
using Entitas;


namespace Ruinum.ECS.Editor.ComponentDrawer
{
    public interface IConfigComponentDrawer
    {
        bool HandlesType(Type type);

        IComponent DrawComponent(IComponent component, IEntity entity);
    }
}
