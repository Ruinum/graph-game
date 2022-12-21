using Ruinum.ECS.Configurations.Game;

using UnityEditor;


namespace Ruinum.ECS.Editor.Configurations
{
    [CustomEditor(typeof(GameEntityConfig))]
    public sealed class GameEntityConfigInspector : EntityConfigInspector<GameEntityConfig, GameContext, GameEntity>
    {
        protected override void OnDrawGUI()
        {
            EditorGUILayout.BeginHorizontal();
           
            EditorGUILayout.EndHorizontal();
        }
    }
}