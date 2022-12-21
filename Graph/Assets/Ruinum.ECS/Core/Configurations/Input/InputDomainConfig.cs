using System.Collections;
using System.Linq;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ruinum.ECS.Configurations.Input
{
    [CreateAssetMenu(menuName = MenuName, fileName = FileName)]
    public sealed class InputDomainConfig : ScriptableObject
    {
        public const string MenuName = EditorConstants.InputMenuPath + FileName;
        public const string FileName = nameof(InputDomainConfig);

        public InputActionAsset Asset;
        [ValueDropdown(nameof(GetActionMaps))]
        public string ActionMap;

        private IEnumerable GetActionMaps() =>
             Asset.actionMaps.Select(a => a.name);
    }
}