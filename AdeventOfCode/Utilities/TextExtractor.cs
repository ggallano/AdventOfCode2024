using System.Text.RegularExpressions;

namespace Utilities
{
    public class TextExtractor
    {

        public static MatchCollection ExtractText(string inputText, string regPattern)
        {
            return Regex.Matches(inputText, regPattern);
        }
    }
}
