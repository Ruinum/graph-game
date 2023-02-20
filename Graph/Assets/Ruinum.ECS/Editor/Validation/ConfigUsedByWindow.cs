using System.Collections.Generic;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Core.Extensions.Native;
using Ruinum.ECS.Core.Extensions.Unity;
using Ruinum.ECS.Core.Systems.Log;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using Object = UnityEngine.Object;
using Ruinum.Editor.Validation;

namespace Ruinum.ECS.Editor.Validation
{
    public sealed class ConfigUsedByWindow : OdinEditorWindow
    {
        private readonly ConfigTree _configTree = new ConfigTree();

        [PropertyOrder(1)] public Object Config;

        [PropertyOrder(2), ShowIf(nameof(IsShowMessage)), ReadOnly, DisplayAsString] public string Message;

        [PropertyOrder(5), ShowIf(nameof(IsConfigUsed)), ListDrawerSettings(IsReadOnly = true, Expanded = true, NumberOfItemsPerPage = 25)]
        public readonly List<UsedConfigPath> Used = new List<UsedConfigPath>();

        [PropertyOrder(0), ShowIf(nameof(IsConfigSelected)), Button(ButtonSizes.Small)]
        public void Clear()
        {
            Config = null;
        }

        [PropertyOrder(3), ShowIf(nameof(IsConfigSelected)), Button(ButtonSizes.Medium), GUIColor(0, 1, 0)]
        public void Find()
        {
            Used.Clear();
            ValidationEditor.ValidateConfigIndexes();
            _configTree.Build();

            foreach (var configTreeObject in _configTree.Objects)
            {
                if (configTreeObject.Value.Count == 0)
                {
                    LogExtention.Error(((Object) configTreeObject.Key).name);
                }
            }

            if (!_configTree.Objects.ContainsKey(Config))
            {
                Message = "Config not used";
                return;
            }
            Message = string.Empty;
            foreach (var (objPath, obj) in _configTree.Objects[Config])
            {
                var path = objPath;
                var config = _configTree.GetConfig(obj, ref path);
                Used.Add(new UsedConfigPath {Obj = config, Path = path});
            }
        }

        private bool IsConfigSelected() => !Config.IsNull();

        private bool IsConfigUsed() => Used.Count > 0;

        private bool IsShowMessage => IsConfigSelected() && !Message.IsNullOrEmpty();

        [MenuItem(EditorConstants.RootMenuWindowName + "/Config used by")]
        public static ConfigUsedByWindow ShowWindow()
        {
            var window = (ConfigUsedByWindow) GetWindow(typeof(ConfigUsedByWindow));
            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(700, 700);
            return window;
        }

        public struct UsedConfigPath
        {
            [HideReferenceObjectPicker, HideLabel] public Object Obj;
            [DisplayAsString(false), HideLabel] public string Path;
        }

        [Button]
        private void FindDuplicateAddressableIdentities()
        {
            var dictionary = new Dictionary<string, List<AddressableAssetEntry>>();
            foreach (var addressableAssetGroup in AddressableAssetSettingsDefaultObject.Settings.groups)
            { 
                foreach (var addressableAssetEntry in addressableAssetGroup.entries)
                {
                    if (!dictionary.ContainsKey(addressableAssetEntry.address))
                    {
                        dictionary.Add(addressableAssetEntry.address, new List<AddressableAssetEntry>());
                    }
                    dictionary[addressableAssetEntry.address].Add(addressableAssetEntry);
                }
            }
            
            foreach (var keyValuePair in dictionary)
            {
                if (keyValuePair.Value.Count > 1)
                {
                    
                    foreach (var addressableAssetEntry in keyValuePair.Value)
                    {
                        Used.Add(new UsedConfigPath {Obj = addressableAssetEntry.MainAsset, Path = addressableAssetEntry.address});
                    }
                }
            }
        }  
    }
}

