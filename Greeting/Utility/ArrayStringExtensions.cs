using System.Linq;

namespace Greeting.Utility
{
    public static class ArrayStringExtensions
    {
        public static string[] Split(this string[] names, char character)
        {
            if (names is null || !names.Any(_ => _.Contains(character))) return names;

            var namesWithComma = names.Where(_ => _.Contains(character)).ToList();
            var splitNames = namesWithComma
                .SelectMany(_ => _.Split(character)
                    .Select(_ =>
                        _.Replace("\"", string.Empty)
                            .Replace(" ", string.Empty)));

            var namesWithoutNamesWithComma = names.Except(namesWithComma).ToList();

            namesWithoutNamesWithComma.AddRange(splitNames);

            return namesWithoutNamesWithComma.ToArray();
        }
    }
}
