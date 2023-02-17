using System.Text.RegularExpressions;

namespace Ruinum.ECS.Parsers
{
    public class DescriptiveNameParser
    {
        protected const string Separator = "_";
        private const string ShortNameGroupName = "short_name";
        private const string PrefixGroupName = "prefix";
        private const string SuffixGroupName = "suffix";
        private const string MajorVersionGroupName = "major";
        private const string MinorVersionGroupName = "minor";
        private const string Pattern =
            @"(?<short_name>(?<prefix>[A-Za-z][\w]*)_(?<major>[0-9]+)_(?<minor>[0-9]+))(_(?<suffix>[\w]+))?";

        protected string Name { get; }
        protected string NameWithVersion { get; private set; } = string.Empty;
        public string Prefix { get; protected set; } = string.Empty;
        public string Suffix { get; protected set; } = string.Empty;
        public int MajorVersion { get; protected set; }
        public int MinorVersion { get; protected set; }

        public DescriptiveNameParser(string source)
        {
            Name = source;
            if (IsMatch(source))
            {
                Parse(source);
            }
        }

        private void Parse(string source)
        {
            var match = Regex.Match(source, Pattern);
            NameWithVersion = match.Groups[ShortNameGroupName].Value;
            Prefix = match.Groups[PrefixGroupName].Value;
            Suffix = match.Groups[SuffixGroupName].Captures.Count > 0
                ? match.Groups[SuffixGroupName].Value
                : string.Empty;
            MajorVersion = int.Parse(match.Groups[MajorVersionGroupName].Value);
            MinorVersion = int.Parse(match.Groups[MinorVersionGroupName].Value);
        }

        public static bool IsMatch(string source) => Regex.IsMatch(source, Pattern);

        public override string ToString() =>
            $"{nameof(Prefix)} : {Prefix}, {nameof(MajorVersion)} : {MajorVersion}, " +
            $"{nameof(MinorVersion)} : {MinorVersion}, {nameof(Suffix)} : {Suffix}";
    }
}