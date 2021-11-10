using System.Linq;

namespace Greeting.Utility
{
    public static class StringExtension
    {
        public static bool IsUpper(this string s) => s.All(char.IsUpper);
    }
}