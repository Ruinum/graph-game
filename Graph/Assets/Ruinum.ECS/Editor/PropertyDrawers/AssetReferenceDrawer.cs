using System;
using Ruinum.ECS.Attributes;
using Ruinum.ECS.Editor.Validation;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

namespace BeastHour.Editor.PropertyDrawers
{
    public sealed class AssetReferenceDrawer<T> : OdinAttributeDrawer<AssetReferenceFieldAttribute, T> where T : AssetReference
    {
        protected override void Initialize()
        {
            if (ValueEntry.SmartValue == null)
            {
                ValueEntry.SmartValue = (T) Activator.CreateInstance(typeof(T), string.Empty);
            }
        }

        protected override void DrawPropertyLayout(GUIContent label)
        {
            EditorGUILayout.BeginHorizontal();
            if (SirenixEditorGUI.IconButton(EditorIcons.Link))
            {
                AssetReferenceWindow.ShowWindow<T>(() => ValueEntry.SmartValue, m => ValueEntry.SmartValue = (T) m);
            }
            if (ValueEntry.SmartValue != null && ValueEntry.SmartValue.editorAsset != null)
            {
                EditorGUI.BeginDisabledGroup(true);
                SirenixEditorFields.UnityObjectField(ValueEntry.SmartValue.editorAsset, typeof(Object), false);
                EditorGUI.EndDisabledGroup();
            }
            else
            {
                EditorGUILayout.LabelField("Empty");
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}