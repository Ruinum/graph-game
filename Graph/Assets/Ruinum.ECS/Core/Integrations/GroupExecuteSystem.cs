using Entitas;
using System.Collections.Generic;

public abstract class GroupExecuteSystem<TEntity> : IExecuteSystem where TEntity : class, IEntity
{
    private readonly IGroup<TEntity> _group;
    private readonly List<TEntity> _entities;

    protected GroupExecuteSystem(IContext<TEntity> context, IMatcher<TEntity> matcher)
    {
        _group = context.GetGroup(matcher);
        _entities = new List<TEntity>();
    }

    public void Execute()
    {
        if (_group.count > 0)
        {
            _group.GetEntities(_entities);
            for (int i = 0, max = _entities.Count; i < max; i++)
            {
                Execute(_entities[i]);
            }
        }
    }

    protected abstract void Execute(TEntity entity);
}
