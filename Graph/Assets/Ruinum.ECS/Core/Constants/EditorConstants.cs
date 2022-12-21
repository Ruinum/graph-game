namespace Ruinum.ECS.Constants
{
    public static class EditorConstants
    {
        public const float EpicLabelWidth = 250;
        public const float LargeLabelWidth = 200;
        public const float MiddleLabelWidth = 150;
        public const float SmallLabelWidth = 100;
        
        public const int MenuHighestPriority = 0;
        public const int MenuHighPriority = 10000;
        public const int MenuMediumPriority = 20000;
        public const int MenuLowPriority = 30000;
        public const int MenuLowestPriority = 40000;

        public const int ValidationEditorValidateAllPriority = MenuHighestPriority + 1;
        public const int ConfigsInitializeOnLoadPriority = MenuHighestPriority + 1;
        public const int RunGameEditorRunGamePriority = MenuLowestPriority + 1;

        public const string CtrlPlusF1 = "%f1";
        public const string CtrlPlusF2 = "%f2";
        public const string CtrlPlusF3 = "%f3";
        public const string ShiftPlusF1 = "#f1";

        public const string RootMenuName = "Ruinum";
        public const string RootMenuPath = RootMenuName + "/";

        public const string ComponentMenuPath = RootMenuPath + "Component" + "/";

        public const string RootMenuValidationName = RootMenuPath + "Validation";
        public const string RootMenuValidationPath = RootMenuValidationName + "/";
        public const string RootMenuSceneName = RootMenuPath + "Scene";
        public const string RootMenuScenePath = RootMenuSceneName + "/";
        public const string RootMenuConfigName = RootMenuPath + "Config";
        public const string RootMenuConfigPath = RootMenuConfigName + "/";
        public const string GameMenuPath = RootMenuPath + "Game" + "/";
        public const string InputMenuPath = RootMenuPath + "Input" + "/";
        public const string UiMenuPath = RootMenuPath + "Ui" + "/";
        public const string StrategyMenuPath = RootMenuPath + "Strategy" + "/";
        public const string EntityStrategyMenuPath = StrategyMenuPath + "Entity" + "/";
        public const string SubscriberStrategyMenuPath = RootMenuPath + "SubscriberStrategy" + "/";
        public const string VectorStrategyMenuPath = StrategyMenuPath + "VectorStrategy" + "/";
        public const string FloatStrategyMenuPath = StrategyMenuPath + "FloatStrategy" + "/";
        public const string PointStrategyMenuPath = StrategyMenuPath + "PointStrategy" + "/";
        public const string FindEntityStrategyMenuPath = StrategyMenuPath + "FindEntity" + "/";
        public const string FloatModifierStrategyMenuPath = StrategyMenuPath + "FloatModifier" + "/";
        public const string TargetEntityStrategyMenuPath = StrategyMenuPath + "Target" + "/";
        public const string StatisticStrategyMenuPath = StrategyMenuPath + "Statistic" + "/";
        public const string ConditionMenuPath = RootMenuPath + "Condition" + "/";
        public const string GameConditionMenuPath = ConditionMenuPath + "Game" + "/";
        public const string InputConditionMenuPath = ConditionMenuPath + "Input" + "/";
        public const string UiConditionMenuPath = ConditionMenuPath + "Ui" + "/";
        public const string SettingsMenuPath = RootMenuPath + "Settings" + "/";
        public const string RootMenuWindowName = RootMenuPath + "Window";
    }
}