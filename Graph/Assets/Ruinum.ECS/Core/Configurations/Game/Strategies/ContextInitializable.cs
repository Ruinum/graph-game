using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

using Ruinum.ECS.Constants;
using Ruinum.ECS.Core.Extensions.Native;
using Ruinum.ECS.Core.Systems.Log;
using Ruinum.ECS.Extensions;
using Ruinum.ECS.Services.Interfaces;

using Sirenix.OdinInspector;
using UnityEngine;


namespace Ruinum.ECS.Configurations.Game.Strategies
{
    public abstract class ContextInitializable : IContextInitializable
    {
#if UNITY_EDITOR
        [DisplayAsString, HideLabel, HorizontalGroup(GroupName = "log"), ShowInInspector, ShowIf("$IsShowStrategyLogging")]
        private string LogGroupHOOK = "";
#endif

        [LabelWidth(EditorConstants.SmallLabelWidth), HideLabel, SuffixLabel("Logging"), HorizontalGroup(GroupName = "log", Width = 60), ShowIf("$IsShowStrategyLogging")]
        public bool Logging;

        private string TypeName;
        private StringBuilder _logBuilder;

        [NonSerialized] protected Contexts Contexts;
        [NonSerialized] protected IGameServices Services;

        protected ContextInitializable()
        {
            Initialize();
        }

        [OnDeserialized]
        public void Initialize()
        {
#if UNITY_EDITOR
            LogGroupHOOK = "";
#endif
            TypeName = GetType().Name;
            _logBuilder = new StringBuilder();
            ConfigInitializer.ValidateConfig(this);
        }

        public void Initialize(Contexts contexts, IGameServices services)
        {
            Contexts = contexts;
            Services = services;
            OnInitialize();
        }

        protected virtual void OnInitialize()
        {
        }

        private bool IsShowStrategyLogging()
        {
#if UNITY_EDITOR
            return true; //UnityEditor.EditorPrefs.GetBool(EditorPrefsConstants.ShowStrategyLogging);
#else
            return false;
#endif
        }

        protected void LogError(string notFoundName, params (string name, object obj)[] foundObjects)
        {
            if (!Logging)
            {
                return;
            }
            _logBuilder.Append($"{notFoundName} ");
            for (int i = 0; i < foundObjects.Length; i++)
            {
                var (name, obj) = foundObjects[i];
                _logBuilder.Append($"{name.FirstCharacterToUpper()}: {obj}; ");
            }

            _logBuilder.Append(TypeName);
            Log(_logBuilder.ToString(), LogType.Error);
            _logBuilder.Clear();
        }

        protected void LogErrorNotFound(string notFoundName, params (string name, object obj)[] foundObjects)
        {
            if(Logging) LogError($"{notFoundName.FirstCharacterToUpper()} not found. ", foundObjects);
        }

        private static void Log(string message, LogType logType)
        {
            LogExtention.Log(message, logType);
        }

        protected bool TryGetEntityByOwner(GameEntity gameEntity, EntityConfig config, out GameEntity target)
        {
            return Services.EntityIndex.TryGetTarget(gameEntity.GetRootOwnerOrThis(), config, out target);
        }

        protected bool TryGetEntitiesByOwner(GameEntity gameEntity, EntityConfig config, out HashSet<GameEntity> target)
        {
            return Services.EntityIndex.TryGetTargets(gameEntity.GetRootOwnerOrThis(), config, out target);
        }
    }
}
