using System.Collections.Generic;
using System.Linq;

namespace Greeting
{
    public class Greeting : IGreeting
    {
        public string Greet(params string[] names)
        {
            if (names is null)
                return Greet(names);

            if (names.Length == 2)
                return Greet(string.Join(" and ", names));

            var lastName = new List<string> { names.Last() };
            var otherNames = names.Except(lastName);
            
            return Greet(string.Join(" and ", names));
        }
            
        private string Greet(string name)
        {
            var greet = "Hello, ";
            return name is null
                ? string.Concat(greet, "my friend", ".")
                : string.Concat(
                    name.All(char.IsUpper) ? greet.ToUpper() : greet,
                    name,
                    name.All(char.IsUpper) ? "!" : "."
                );
        }
    }
}