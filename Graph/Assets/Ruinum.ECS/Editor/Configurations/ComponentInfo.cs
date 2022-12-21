using System;

namespace Ruinum.ECS.Editor.Configurations
{
    [Serializable]
    public sealed class ComponentInfo
    {
        public string Name;
        public string Info;

        public ComponentInfo(string name)
        {
            Name = name;
        }
    }
}