namespace BirdNet.Extensions;

public static class StringExtensions
{
    public static string ToTitleCase(this string str)
    {
        string[] words = str.Split(' ');
        List<string> resultStrings = [];

        foreach (string word in words)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                continue;
            }
            
            if (word.Length == 1)
            {
                resultStrings.Add(word.ToUpper());
            }

            resultStrings.Add(word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower());
        }

        return string.Join(" ", resultStrings);
    }
}