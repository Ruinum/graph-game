using System;

using Entitas;
using Sirenix.OdinInspector.Editor;
using UnityEditor;

using Ruinum.ECS.Entity.Interfaces;
using Ruinum.Entities.Game;
using Ruinum.ECS.Configurations;


namespace Ruinum.ECS.Editor.Configurations
{
    public abstract class EntityConfigInspector<TConfig, TContext, TEntity> : OdinEditor 
        where TConfig : EntityConfig<TEntity> where TContext : IContext<TEntity> where TEntity : class, IEntityComponentCopy, IConfigIndexEntity
    {
        private IContext _context;
        public TConfig Config;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            Config = (TConfig) target;
            _context = Activator.CreateInstance<TContext>();
        }

        public override void OnInspectorGUI()
        {
            if (_context == null)
            {
                Initialize();
            }
            EditorGUI.BeginChangeCheck();
            DrawDefaultInspector();
            EntityConfigDrawer.DrawComponents(_context, Config);
            OnDrawGUI();
            EditorUtility.SetDirty(Config);
        }

        protected virtual void OnDrawGUI()
        {

        }
    }
}