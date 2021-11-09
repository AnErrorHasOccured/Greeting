using System.Linq;

namespace Greeting
{
    public static class StringExtension
    {
        public static bool IsUpper(this string s) => s.All(char.IsUpper);
    }
}