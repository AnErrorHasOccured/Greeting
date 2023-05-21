using System.Linq;

namespace Greeting.Utility;

public static class ArrayStringExtensions
{
    public static string[] NormalizeNames(this string[] names)
    {
        if (names?.Any(_ => _.Contains("\"")) ?? false)
        {
            var escape = names?.Where(x => x.Contains("\"")).ToArray();
            var escapeClear = escape?.Select(x => x.Replace("\"", string.Empty)).ToArray();

            return names.Except(escape).Concat(escapeClear).ToArray();
        }

        if (names?.Any(_ => _.Contains(",")) ?? false)
        {
            var comma = names?.Where(x => x.Contains(",")).ToArray();
            var split = comma.SelectMany(x => x.Split(","));
            var splitClear = split.Select(_ => _.Replace(" ", string.Empty));

            return names.Except(comma).Concat(splitClear).ToArray();
        }

        return names;
    }
}