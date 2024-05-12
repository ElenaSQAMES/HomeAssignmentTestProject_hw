
using System.Text.RegularExpressions;

namespace HomeAssignmentTestProject.Resources.Pages
{
    public static partial class CommonMethods
    {
        public static Dictionary<string, int> ProcessText(string text)
        {
            var processedText = GetCleanText(text);
            var words = processedText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return words
                .GroupBy(word => word)
                .ToDictionary(group => group.Key, group => group.Count());
        }

        private static string GetCleanText(string text)
        {
            var regex = new Regex("\\[[^\\]]*?\\]|\\d+|\\W+");
            return regex.Replace(text.ToLower(), " ");
        }
    }
}


     