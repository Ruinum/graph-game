namespace Ruinum.ECS.Editor.Constants
{
    public static class AssetPathsConstants
    {
        public const string AssetExtension = ".asset";
        public const string ComponentInfoAssetFolder = "Assets/Content/Editor";
        public const string ComponentInfoAssetFolderPath = ComponentInfoAssetFolder + "/";
        public const string GameComponentInfoAssetPath = ComponentInfoAssetFolderPath + "GameComponentInfoConfig" + AssetExtension;
        public const string NetworkComponentInfoAssetPath = ComponentInfoAssetFolderPath + "GameComponentInfoConfig" + AssetExtension;
        public const string ConditionInfoAssetPath = ComponentInfoAssetFolderPath + "GameComponentInfoConfig" + AssetExtension;

        public const string EntityConfigGraphsAssetFolder = ComponentInfoAssetFolderPath + "EntityConfigGraphs";
        public const string EntityConfigGraphsAssetFolderPath = ComponentInfoAssetFolderPath + "EntityConfigGraphs/";
        public const string StateGraphsAssetFolder = ComponentInfoAssetFolderPath + "StateGraphs";
        public const string StateGraphsAssetFolderPath = ComponentInfoAssetFolderPath + "StateGraphs/";
    }
}