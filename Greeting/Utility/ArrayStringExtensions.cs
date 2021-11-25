using System.Linq;

namespace Greeting.Utility
{
    public static class ArrayStringExtensions
    {
        public static string[] NormalizeNames(this string[] names)
        {
            if (names?.Any(_ => _.Contains("\"")) ?? false)
            {
                var escape2 = names?.Where(x => x.Contains("\"")).ToArray();
                var escapeClear = escape2?.Select(x => x.Replace("\"", string.Empty)).ToArray();

                return names.Except(escape2).Concat(escapeClear).ToArray();
            }

            if (names?.Any(_ => _.Contains(",")) ?? false)
            {
                var comma2 = names?.Where(x => x.Contains(",")).ToArray();
                var split = comma2.SelectMany(x => x.Split(","));
                var splitClear = split.Select(_ => _.Replace(" ", string.Empty));

                return names.Except(comma2).Concat(splitClear).ToArray();
            }

            return names;
        }
    }
}
