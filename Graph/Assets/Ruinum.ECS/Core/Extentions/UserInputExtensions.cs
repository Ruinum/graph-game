using System.Collections.Generic;
using System.Linq;

namespace Ruinum.ECS.Extensions
{
    public static class UserInputExtensions
    {
        public static IEnumerable<string> GetActionNamesByMap(this UserInput input, string mapName) =>
            input.asset.FindActionMap(mapName).actions
                .Select(a => a.name);
        
        public static IEnumerable<string> GetGameActionNames(this UserInput input) =>
            input.GetActionNamesByMap("Game")
                .Where(n => !n.Equals("Move") && !n.Equals("Look")); //TODO: change string name. Move to constants
    }
}