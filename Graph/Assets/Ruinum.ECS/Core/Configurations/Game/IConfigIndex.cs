using System.Collections.Generic;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Indexes
{
    public interface IConfigIndex { }

    public interface IConfigIndex<T> : IConfigIndex where T : ScriptableObject
    {
        T GetConfig(int index);

#if UNITY_EDITOR
        void Validate(T obj);

        void ValidateEditor(bool setDirty = true);
        
        List<T> GetConfigs();
#endif
    }
}