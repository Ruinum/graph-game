using Ruinum.ECS.Configurations.Input;
using Ruinum.ECS.Core.Configurations;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game
{ 
    public sealed class GameConfig : ScriptableObject
    {
        public GameEntityConfig MainEntity;
        public InputDomainConfig DefaultInputDomain;
        public SceneConfigName[] SceneNames;

        [Serializable, TableList]
        public sealed class SceneConfigName
        {
            public string Name;
            public SceneConfig Config;
        }
    }
}