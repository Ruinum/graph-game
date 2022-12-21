using System;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine.AddressableAssets;

namespace Ruinum.ECS.Editor.Validation
{
    [ShowOdinSerializedPropertiesInInspector]
    public sealed class AssetReferenceWindow : OdinEditorWindow
    {
        [InlineEditor(InlineEditorObjectFieldModes.CompletelyHidden), OnValueChanged(nameof(ValueChanged), true)] public AssetReferenceEditorObject Reference;
        private Action<AssetReference> _setAction;

        [Button(ButtonSizes.Large)]
        public void Apply()
        {
            ValueChanged();
            EditorUtility.SetDirty(this);
            Close();
        }
        
        private void ValueChanged()
        {
            if (Reference.Reference != null)
            {
                _setAction(Reference.Reference);
            }
        } 
        
        public static void ShowWindow<TReference>(Func<AssetReference> getFunc, Action<AssetReference> setAction) where TReference : AssetReference
        {
            ShowWindow(typeof(TReference), getFunc, setAction);
        }
        
        public static void ShowWindow(Type referenceType, Func<AssetReference> getFunc, Action<AssetReference> setAction)
        {
            var window =(AssetReferenceWindow) GetWindow(typeof(AssetReferenceWindow));
            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(700, 100);
            var referenceEditor = CreateInstance<AssetReferenceEditorObject>();
            var reference = getFunc.Invoke();
            referenceEditor.Reference = reference == null || !reference.RuntimeKeyIsValid()
                ? (AssetReference) Activator.CreateInstance(referenceType, string.Empty)
                : reference;

            window.Reference = referenceEditor;
            window._setAction = setAction;
        }
    }
}