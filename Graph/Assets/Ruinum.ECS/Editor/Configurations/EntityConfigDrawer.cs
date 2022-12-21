using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using DesperateDevs.Serialization;
using DesperateDevs.Unity.Editor;
using DesperateDevs.Utils;

using Entitas;
using Entitas.VisualDebugging.Unity.Editor;

using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;

using UnityEditor;
using UnityEngine;

using Ruinum.ECS.Configurations;
using Ruinum.ECS.Core.Extensions.Native;
using Ruinum.ECS.Editor.ComponentDrawer;
using Ruinum.ECS.Editor.EntityStateGraph;
using Ruinum.Editor;

namespace Ruinum.ECS.Editor.Configurations {

    public static class EntityConfigDrawer
    {
        private static AddComponentSelector AddComponentSelector = new AddComponentSelector();
        private static readonly List<string> AddComponentSelectorBuffer = new List<string>();
        
        public static void DrawComponents(IContext context, EntityConfig entityConfig, bool defaultUnfolded = true) 
        {
            var unfoldedComponents = GetUnfoldedComponents(context, defaultUnfolded);
            var componentMemberSearch = GetComponentMemberSearch(context);
            var unfoldedInfos = GetUnfoldedInfos(context);
            var componentList = entityConfig.GetComponents();
            var indices = entityConfig.GetComponentIndexes();
            EditorLayout.BeginVerticalBox();
            {
                EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
                {
                    EditorGUILayout.LabelField("Components (" + componentList.Length + ")", EditorStyles.boldLabel);

                    if (EditorLayout.MiniButtonLeft("▸"))
                    {
                        for (int i = 0; i < unfoldedComponents.Length; i++)
                        {
                            unfoldedComponents[i] = false;
                        }
                    }

                    if (EditorLayout.MiniButtonRight("▾"))
                    {
                        for (int i = 0; i < unfoldedComponents.Length; i++)
                        {
                            unfoldedComponents[i] = true;
                        }
                    }
                }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.Space();
                if (SirenixEditorGUI.ToolbarButton("Add component"))
                {
                    AddComponentSelector = new AddComponentSelector();
                    AddComponentSelector.Show(GetAddComponentMenuSelection(context, entityConfig, AddComponentSelectorBuffer), entityConfig, OnAddComponent);
                }

                EditorGUILayout.Space();

                ComponentNameSearchString = EditorLayout.SearchTextField(ComponentNameSearchString);

                EditorGUILayout.Space();


                var contextInfo = GetComponentInfos(context);

                for (int i = 0; i < componentList.Length; i++)
                {
                    var componentIndex = indices[i];
                    var componentInfo = contextInfo.AllComponents[componentIndex];
                    var data = new DrawComponentData
                    {
                        UnfoldedComponents = unfoldedComponents,
                        UnfoldedInfos = unfoldedInfos,
                        ComponentMemberSearch = componentMemberSearch,
                        Context = context,
                        Config = entityConfig,
                        ComponentInfo = componentInfo,
                        Component = componentList[i]
                    };
                    DrawComponent(data, entityConfig); 
                }

            }
            EditorLayout.EndVerticalBox();
        }
        
        private static void OnAddComponent(EntityConfig config, string componentToAddName)
        {
            if (string.IsNullOrEmpty(componentToAddName))
            {
                return;
            }
            var componentIndex = config.ComponentNames.IndexOf(componentToAddName);
            if (componentIndex > -1)
            {
                if (!config.HasComponent(componentIndex))
                {
                    var componentType = config.ComponentTypes[componentIndex];
                    var component = (IComponent) Activator.CreateInstance(componentType);
                    config.AddComponent(componentIndex, component);
                }
            }
            EditorUtility.SetDirty(config);
        }
        
        public static void DrawComponent(DrawComponentData data, EntityConfig config)
        {
            var index = data.ComponentInfo.Index;
            var componentType = data.ComponentInfo.Type;
            var componentName = data.ComponentInfo.Name;
            if (!EditorLayout.MatchesSearchString(data.ComponentInfo.NameLower, ComponentNameSearchString.ToLower()))
            {
                return;
            }
            var boxStyle = GetColoredBoxStyle(data.Context, index);
            EditorGUILayout.BeginVertical(boxStyle, GUILayout.ExpandWidth(true));
            {
                if (data.UnfoldedInfos[index])
                {
                    boxStyle.CalcMinMaxWidth(new GUIContent(data.ComponentInfoText), out _, out var max);
                    var lines = data.ComponentInfoText.Split('\n').Length;

                    EditorGUILayout.LabelField(new GUIContent(data.ComponentInfoText), GUILayout.Width(max), GUILayout.Height(lines == 1 ? 16 : lines * 14f));
                }

                EditorGUILayout.BeginHorizontal();
                var memberInfos = componentType.GetPublicMemberInfos();

                if (memberInfos.Count == 0)
                {
                    EditorGUILayout.LabelField(componentName, EditorStyles.boldLabel);
                }
                else
                {
                    data.UnfoldedComponents[index] = EditorLayout.Foldout(data.UnfoldedComponents[index], componentName, FoldoutStyle);
                    if (data.UnfoldedComponents[index])
                    {
                        data.ComponentMemberSearch[index] = memberInfos.Count > 5 ? EditorLayout.SearchTextField(data.ComponentMemberSearch[index]) : string.Empty;
                    } 
                }

                if (!string.IsNullOrWhiteSpace(data.ComponentInfoText) && EditorLayout.MiniButton("?"))
                {
                    data.UnfoldedInfos[index] = !data.UnfoldedInfos[index];
                }
                if (EditorLayout.MiniButton("-"))
                {
                    config.RemoveComponent(index);
                }
                EditorGUILayout.EndHorizontal();
                if (data.UnfoldedComponents[index])
                {
                    var newComponent = (IComponent) Activator.CreateInstance(componentType);
                    data.Component.CopyPublicMemberValues(newComponent);

                    var changed = false;
                    var componentDrawer = GetComponentDrawer(componentType);
                    if (componentDrawer != null)
                    {
                        EditorGUI.BeginChangeCheck();
                        {
                            componentDrawer.DrawComponent(newComponent, data.Config);
                        }
                        changed = EditorGUI.EndChangeCheck();
                    }
                    else
                    {
                        for (var i = 0; i < memberInfos.Count; i++)
                        {
                            var info = memberInfos[i];
                            if (EditorLayout.MatchesSearchString(info.name.ToLower(),
                                data.ComponentMemberSearch[index].ToLower()))
                            {
                                var memberValue = info.GetValue(newComponent);
                                var memberType = memberValue == null ? info.type : memberValue.GetType();
                                if (DrawObjectMember(memberType, info.name, memberValue, newComponent, info.SetValue))
                                {
                                    changed = true;
                                }
                            }
                        }
                    }
                    if (changed)
                    {
                        data.Config.ReplaceComponent(index, newComponent);
                    }
                }
            }
            EditorLayout.EndVerticalBox();
        }

        public static bool DrawObjectMember(Type memberType, string memberName, object value, object target, Action<object, object> setValue) {
            if (value == null) {
                EditorGUI.BeginChangeCheck();
                {
                    var isUnityObject = memberType == typeof(UnityEngine.Object) || memberType.IsSubclassOf(typeof(UnityEngine.Object));
                    EditorGUILayout.BeginHorizontal();
                    {
                        if (isUnityObject) {
                            setValue(target, EditorGUILayout.ObjectField(memberName, (UnityEngine.Object)value, memberType, true));
                        } else {
                            EditorGUILayout.LabelField(memberName, "null");
                        }
                    }
                    EditorGUILayout.EndHorizontal();
                }

                return EditorGUI.EndChangeCheck();
            }

            if (!memberType.IsValueType) {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.BeginVertical();
            }

            EditorGUI.BeginChangeCheck();
            {
                var typeDrawer = GetTypeDrawer(memberType);
                if (typeDrawer != null) {
                    var newValue = typeDrawer.DrawAndGetNewValue(memberType, memberName, value, target);
                    setValue(target, newValue);
                } else {
                    var targetType = target.GetType();
                    var shouldDraw = !targetType.ImplementsInterface<IComponent>();
                    if (shouldDraw) {
                        EditorGUILayout.LabelField(memberName, value.ToString());

                        var indent = EditorGUI.indentLevel;
                        EditorGUI.indentLevel += 1;

                        EditorGUILayout.BeginVertical();
                        {
                            var list = memberType.GetPublicMemberInfos();
                            for (var index = 0; index < list.Count; index++)
                            {
                                var info = list[index];
                                var mValue = info.GetValue(value);
                                var mType = mValue == null ? info.type : mValue.GetType();
                                DrawObjectMember(mType, info.name, mValue, value, info.SetValue);
                                if (memberType.IsValueType)
                                {
                                    setValue(target, value);
                                }
                            }
                        }
                        EditorGUILayout.EndVertical();

                        EditorGUI.indentLevel = indent;
                    } else {
                        DrawUnsupportedType(memberType, memberName, value);
                    }
                }

                if (!memberType.IsValueType) {
                    EditorGUILayout.EndVertical();
                    if (EditorLayout.MiniButton("×")) {
                        setValue(target, null);
                    }

                    EditorGUILayout.EndHorizontal();
                }
            }

            return EditorGUI.EndChangeCheck();
        }
        
        private static readonly List<int> addComponentMenuBufferIndexes = new List<int>();
        private static readonly List<string> addComponentMenuBufferNames = new List<string>();

        public static List<string> GetAddComponentMenuSelection(IContext context, EntityConfig config, List<string> buffer)
        {
            buffer.Clear();
            var componentInfos = GetComponentInfos(context)?.ConfigComponentsOrdered;
            if (componentInfos == null)
            {
                return buffer;
            }
            for (int i = 0, max = componentInfos.Length; i < max; i++)
            {
                var info = componentInfos[i];
                if (!config.HasComponent(info.Index))
                {
                    buffer.Add(info.Name);
                }
            }
            return buffer;
        }

        private static void DrawUnsupportedType(Type memberType, string memberName, object value) {
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField(memberName, value.ToString());
                if (EditorLayout.MiniButton("Missing ITypeDrawer")) {
                    var typeName = memberType.ToCompilableString();
                    if (EditorUtility.DisplayDialog(
                        "No ITypeDrawer found",
                        "There's no ITypeDrawer implementation to handle the type '" + typeName + "'.\n" +
                        "Providing an ITypeDrawer enables you draw instances for that type.\n\n" +
                        "Do you want to generate an ITypeDrawer implementation for '" + typeName + "'?\n",
                        "Generate",
                        "Cancel"
                    )) {
                        GenerateITypeDrawer(typeName);
                    }
                }
            }
            EditorGUILayout.EndHorizontal();
        }

        public static void GenerateIDefaultInstanceCreator(string typeName) {
            var preferences = new Preferences("Entitas.properties", Environment.UserName + ".userproperties");
            var config = preferences.CreateAndConfigure<VisualDebuggingConfig>();
            var folder = config.defaultInstanceCreatorFolderPath;
            var filePath = folder + Path.DirectorySeparatorChar + "Default" + typeName.ShortTypeName() + "InstanceCreator.cs";
            var template = DefaultInstanceCreatorTemplateFormat
                .Replace("${Type}", typeName)
                .Replace("${ShortType}", typeName.ShortTypeName());
            GenerateTemplate(folder, filePath, template);
        }

        public static void GenerateITypeDrawer(string typeName) {
            var preferences = new Preferences("Entitas.properties", Environment.UserName + ".userproperties");
            var config = preferences.CreateAndConfigure<VisualDebuggingConfig>();
            var folder = config.typeDrawerFolderPath;
            var filePath = folder + Path.DirectorySeparatorChar + typeName.ShortTypeName() + "TypeDrawer.cs";
            var template = TypeDrawerTemplateFormat
                .Replace("${Type}", typeName)
                .Replace("${ShortType}", typeName.ShortTypeName());
            GenerateTemplate(folder, filePath, template);
        }

        private static void GenerateTemplate(string folder, string filePath, string template) {
            if (!Directory.Exists(folder)) {
                Directory.CreateDirectory(folder);
            }

            File.WriteAllText(filePath, template);
            EditorApplication.isPlaying = false;
            AssetDatabase.Refresh();
            Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(filePath);
        }

        private const string DefaultInstanceCreatorTemplateFormat =
            @"using System;
using Entitas.VisualDebugging.Unity.Editor;

public class Default${ShortType}InstanceCreator : IDefaultInstanceCreator {

    public bool HandlesType(Type type) {
        return type == typeof(${Type});
    }

    public object CreateDefault(Type type) {
        // TODO return an instance of type ${Type}
        throw new NotImplementedException();
    }
}
";

        private const string TypeDrawerTemplateFormat =
            @"using System;
using Entitas;
using Entitas.VisualDebugging.Unity.Editor;

public class ${ShortType}TypeDrawer : ITypeDrawer {

    public bool HandlesType(Type type) {
        return type == typeof(${Type});
    }

    public object DrawAndGetNewValue(Type memberType, string memberName, object value, object target) {
        // TODO draw the type ${Type}
        throw new NotImplementedException();
    }
}
";

        public sealed class DrawComponentData
        {
            public bool[] UnfoldedComponents;
            public bool[] UnfoldedInfos;
            public string[] ComponentMemberSearch;
            public IContext Context;
            public EntityConfig Config;
            public ComponentInfo ComponentInfo;
            public IComponent Component;
            public string ComponentInfoText;
        }

        private static Dictionary<IContext, bool[]> _contextToUnfoldedInfo;
        public static Dictionary<IContext, bool[]> ContextToUnfoldedInfo => _contextToUnfoldedInfo ?? (_contextToUnfoldedInfo = new Dictionary<IContext, bool[]>());

        private static Dictionary<IContext, bool[]> _contextToUnfoldedComponents;
        public static Dictionary<IContext, bool[]> ContextToUnfoldedComponents
        {
            get { if (_contextToUnfoldedComponents == null) { _contextToUnfoldedComponents = new Dictionary<IContext, bool[]>(); } return _contextToUnfoldedComponents; }
        }

        private static Dictionary<IContext, string[]> _contextToComponentMemberSearch;
        public static Dictionary<IContext, string[]> ContextToComponentMemberSearch
        {
            get { if (_contextToComponentMemberSearch == null) { _contextToComponentMemberSearch = new Dictionary<IContext, string[]>(); } return _contextToComponentMemberSearch; }
        }

        private static Dictionary<IContext, GUIStyle[]> _contextToColoredBoxStyles;
        public static Dictionary<IContext, GUIStyle[]> ContextToColoredBoxStyles
        {
            get { if (_contextToColoredBoxStyles == null) { _contextToColoredBoxStyles = new Dictionary<IContext, GUIStyle[]>(); } return _contextToColoredBoxStyles; }
        }

        public struct ComponentInfo
        {
            public int Index;
            public string Name;
            public Type Type;
            public string NameLower;
        }

        private static Dictionary<string, ContextComponentInfo> _contextToComponentInfos;
        public static Dictionary<string, ContextComponentInfo> ContextToComponentInfos => 
            _contextToComponentInfos ?? (_contextToComponentInfos = new Dictionary<string, ContextComponentInfo>());

        private static GUIStyle _foldoutStyle;
        public static GUIStyle FoldoutStyle
        {
            get { if (_foldoutStyle == null) { _foldoutStyle = new GUIStyle(EditorStyles.foldout);
                _foldoutStyle.fontStyle = FontStyle.Bold;
                _foldoutStyle.stretchWidth = true;
            } return _foldoutStyle; }
        }

        private static string _componentNameSearchString;

        private static string ComponentNameSearchString
        {
            get => _componentNameSearchString ??= string.Empty;
            set => _componentNameSearchString = value;
        }

        private static readonly ITypeDrawer[] TypeDrawers;
        private static readonly IConfigComponentDrawer[] ComponentDrawers;

        static EntityConfigDrawer()
        {
            TypeDrawers = GetInstancesOfType<ITypeDrawer>();
            ComponentDrawers = GetInstancesOfType<IConfigComponentDrawer>();
        }

        private static T[] GetInstancesOfType<T>()
        {
            return Sirenix.Utilities.AssemblyUtilities.GetTypes(AssemblyTypeFlags.All)
                .Where(m => typeof(T).IsAssignableFrom(m) && !m.IsAbstract)
                .Select(m => (T) Activator.CreateInstance(m)).ToArray();
        }

        private static bool[] GetUnfoldedInfos(IContext context)
        {
            if (!ContextToUnfoldedInfo.TryGetValue(context, out var unfoldedInfo))
            {
                unfoldedInfo = new bool[context.totalComponents];
                for (int i = 0; i < unfoldedInfo.Length; i++)
                {
                    unfoldedInfo[i] = false;
                }
                ContextToUnfoldedInfo.Add(context, unfoldedInfo);
            }
            return unfoldedInfo;
        }

        private static bool[] GetUnfoldedComponents(IContext context, bool defaultUnfolded = true)
        {
            bool[] unfoldedComponents;
            if (!ContextToUnfoldedComponents.TryGetValue(context, out unfoldedComponents))
            {
                unfoldedComponents = new bool[context.totalComponents];
                for (int i = 0; i < unfoldedComponents.Length; i++)
                {
                    unfoldedComponents[i] = defaultUnfolded;
                }
                ContextToUnfoldedComponents.Add(context, unfoldedComponents);
            }

            return unfoldedComponents;
        }

        private static string[] GetComponentMemberSearch(IContext context)
        {
            string[] componentMemberSearch;
            if (!ContextToComponentMemberSearch.TryGetValue(context, out componentMemberSearch))
            {
                componentMemberSearch = new string[context.totalComponents];
                for (int i = 0; i < componentMemberSearch.Length; i++)
                {
                    componentMemberSearch[i] = string.Empty;
                }
                ContextToComponentMemberSearch.Add(context, componentMemberSearch);
            }

            return componentMemberSearch;
        }

        public sealed class ContextComponentInfo
        {
            public ComponentInfo[] AllComponents;
            public ComponentInfo[] ConfigComponentsOrdered;
        }

        private static ContextComponentInfo GetComponentInfos(IContext context)
        {
            if (!ContextToComponentInfos.TryGetValue(context.contextInfo.name, out var infos))
            {
                var contextInfo = context.contextInfo;
                var infosList = new List<ComponentInfo>(contextInfo.componentTypes.Length);
                for (int i = 0; i < contextInfo.componentTypes.Length; i++)
                {
                    var name = contextInfo.componentNames[i];
                    infosList.Add(new ComponentInfo {Index = i, Name = contextInfo.componentNames[i], Type = contextInfo.componentTypes[i], NameLower = name.ToLower()});
                }
                var configComponents = infosList.Where(m => context.contextInfo.componentTypes[m.Index].HasEditorComponentAttribute()).OrderBy(m => m.Name).ToArray();
                infos = new ContextComponentInfo {AllComponents = infosList.ToArray(), ConfigComponentsOrdered = configComponents};
                ContextToComponentInfos.Add(contextInfo.name, infos);
            }

            return infos;
        }

        private static GUIStyle GetColoredBoxStyle(IContext context, int index)
        {
            GUIStyle[] styles;
            if (!ContextToColoredBoxStyles.TryGetValue(context, out styles) || styles[index].normal.background == null)
            {
                styles = new GUIStyle[context.totalComponents];
                for (int i = 0; i < styles.Length; i++)
                {
                    var hue = (float)i / (float)context.totalComponents;
                    var componentColor = Color.HSVToRGB(hue, 0.7f, 1f);
                    componentColor.a = 0.15f;
                    var boxStyle = GUI.skin.box;
                    var style = new GUIStyle();
                    style.alignment = boxStyle.alignment;
                    style.border = boxStyle.border;
                    style.margin = boxStyle.margin;
                    style.overflow = boxStyle.overflow;
                                            
                    style.clipping = boxStyle.clipping;
                    style.font = boxStyle.font;
                    style.hover = boxStyle.hover;
                    style.padding = boxStyle.padding;
                    style.contentOffset = boxStyle.contentOffset;
                    style.fixedHeight = boxStyle.fixedHeight;
                    style.fixedWidth = boxStyle.fixedWidth;
                    style.fontSize = boxStyle.fontSize;
                    style.fontStyle = boxStyle.fontStyle;
                    style.imagePosition = boxStyle.imagePosition;
                    style.richText = boxStyle.richText;
                    style.stretchHeight = boxStyle.stretchHeight;
                    style.stretchWidth = boxStyle.stretchWidth;
                    style.wordWrap = boxStyle.wordWrap;
                    style.focused = boxStyle.focused;
                                            
                    style.normal.background = CreateTexture(2, 2, componentColor);
                    styles[i] = style;
                }
                ContextToColoredBoxStyles[context] = styles;
            }
            return styles[index];
        }

        private static Texture2D CreateTexture(int width, int height, Color color)
        {
            var pixels = new Color[width * height];
            for (int i = 0; i < pixels.Length; ++i)
            {
                pixels[i] = color;
            }
            var result = new Texture2D(width, height);
            result.SetPixels(pixels);
            result.Apply();
            return result;
        }

        private static IConfigComponentDrawer GetComponentDrawer(Type type)
        {
            for (var index = 0; index < ComponentDrawers.Length; index++)
            {
                var drawer = ComponentDrawers[index];
                if (drawer.HandlesType(type))
                {
                    return drawer;
                }
            }

            return null;
        }

        private static ITypeDrawer GetTypeDrawer(Type type)
        {
            for (var index = 0; index < TypeDrawers.Length; index++)
            {
                var drawer = TypeDrawers[index];
                if (drawer.HandlesType(type))
                {
                    return drawer;
                }
            }

            return null;
        }

    }
}
