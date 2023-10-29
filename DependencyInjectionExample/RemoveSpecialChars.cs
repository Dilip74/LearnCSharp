using System.Text;
using System.Text.RegularExpressions;

namespace DependencyInjectionExample
{
    public static class RemoveSpecialChars
    {
        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_' || c == ' ')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string RemoveSplChars(string text)
        {
            return Regex.Replace(text, "[^0-9A-Za-z _-]", "");
        }
    }
}
