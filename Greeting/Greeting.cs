using System.Collections.Generic;
using System.Linq;

namespace Greeting
{
    public class Greeting : IGreeting
    {
        public string Greet(params string[] names)
        {
            if (names is null)
                return Greet((string)null) + ".";

            names = SplitNames(names, ",");

            if (names.Length == 1)
                return Greet(names.First()) + (names.First().IsUpper() ? "!" : ".");

            if (names.Length == 2)
                return Greet(string.Join(" and ", names)) + ".";

            if (names.Length > 2 && names.Any(_ => _.IsUpper()))
            {
                var uppers = names.Where(_ => _.IsUpper());
                var normal = names.Except(uppers);

                return Greet(string.Join(" and ", normal)) + ". AND HELLO " + string.Join(", ", uppers) + "!";
            }

            if (names.Length > 2)
            {
                var lastName = new List<string> { names.Last() };
                var otherNames = names.Except(lastName);

                return Greet(string.Join(", ", otherNames)) + " and " + lastName.First() + ".";
            }

            return null;
        }

        private static string[] SplitNames(string[] names, string character)
        {
            if (!names.Any(_ => _.Contains(character))) return names;

            var namesWithComma = names.Where(_ => _.Contains(",")).ToList();
            var splitNames = namesWithComma
                .SelectMany(_ => _.Split(",")
                    .Select(_ =>
                        _.Replace("\"", string.Empty)
                            .Replace(" ", string.Empty)));
            var namesWithoutNamesWithComma = names.Except(namesWithComma).ToList();

            namesWithoutNamesWithComma.AddRange(splitNames);

            return namesWithoutNamesWithComma.ToArray();
        }

        private string Greet(string name)
        {
            var basePrashe = "{0}, {1}";
            var greet = "Hello";

            if (name is null)
                return string.Format(basePrashe, greet, "my friend");

            if (name.IsUpper())
                return string.Format(basePrashe, greet.ToUpper(), name);

            return string.Format(basePrashe, greet, name);
        }
    }
}