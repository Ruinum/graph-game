using System;

using Entitas;
using Sirenix.Utilities.Editor;
using Ruinum.ECS.Editor.Validation;

using UnityEditor;
using UnityEngine.AddressableAssets;

using Object = UnityEngine.Object;

namespace Ruinum.ECS.Editor.ComponentDrawer
{
    public abstract class ResourceComponentDrawer<TComponent, TObject, TReference> : IConfigComponentDrawer
        where TComponent : ResourceComponent<TReference>
        where TObject : Object
        where TReference : AssetReference
    {
        protected abstract string FieldLabel { get; }

        public bool HandlesType(Type type)
        {
            return typeof(TComponent) == type;
        }

        public IComponent DrawComponent(IComponent component, IEntity entity)
        {
            var castedComponent = (ResourceComponent<TReference>) component;
            if (SirenixEditorGUI.IconButton(EditorIcons.PenAdd))
            {
                AssetReferenceWindow.ShowWindow<TReference>(() => castedComponent.Reference, m => castedComponent.SetReference(m));
            }

            if (castedComponent.Reference != null && castedComponent.Reference.editorAsset != null)
            {
                EditorGUI.BeginDisabledGroup(true);
                SirenixEditorFields.UnityObjectField(FieldLabel, castedComponent.Reference.editorAsset, typeof(TObject), false);
                EditorGUI.EndDisabledGroup();
            }
            else
            {
                EditorGUILayout.LabelField("Empty");
            }

            return component;
        }
    }
}