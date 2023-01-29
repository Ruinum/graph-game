using System.Collections;
using Ruinum.ECS.Configurations.Conditions.Input;
using Ruinum.ECS.Configurations.Input;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Core.Conditions;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Conditions.Entities.Input
{
    public sealed class InputButtonCondition : EntityCondition
    {
        public InputDomainConfig InputDomain;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public InputButtonInteractType Interaction;
        [ValueDropdown(nameof(GetActionsNames))] public string ActionName;

        private IEnumerable GetActionsNames() =>
            new UserInput().GetGameActionNames();

        protected override bool IsTrue(GameEntity entity)
        {
            return Contexts.sharedInstance.game.services.Instance.Input.IsButtonInteracted(InputDomain.ActionMap, ActionName, Interaction);
        }
    }
}