using System;

namespace Ruinum.ECS.Editor.Configurations
{
    public sealed class GameComponentInfoConfig : ComponentInfoConfig
    {
        protected override string[] ComponentNames => GameComponentsLookup.componentNames;

        protected override Type[] ComponentTypes => GameComponentsLookup.componentTypes;

        public override Type EntityType => typeof(GameEntity);
    }
}