using System.Collections.Generic;
using System.Linq;

namespace Ruinum.ECS.Parsers
{
    public sealed class LevelSceneNameParser : DescriptiveNameParser
    {
        private const string LevelScenePrefix = "Level";
        private static readonly string[] Suffixes = {"Audio", "Lighting", "Topology"};
        public readonly IEnumerable<string> AdditionalSceneNames;

        public LevelSceneNameParser(string sceneName) : base(sceneName) =>
            AdditionalSceneNames = IsLevelScene()
                ? Suffixes.Select(suffix => $"{NameWithVersion}{Separator}{suffix}")
                : Enumerable.Empty<string>();

        public bool IsLevelScene() => NameWithVersion.Equals(Name) && NameWithVersion.Contains(LevelScenePrefix);
    }
}