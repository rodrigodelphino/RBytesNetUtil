public static class StringExtensions
{
    public static string SubstituirTudo(this string originalString, string oldValue, string newValue, StringComparison comparisonType = StringComparison.Ordinal)
    {
        int startIndex = 0;
        while (true)
        {
            startIndex = originalString.IndexOf(oldValue, startIndex, comparisonType);
            if (startIndex == -1)
                break;
            originalString = originalString.Substring(0, startIndex) + newValue + originalString.Substring(startIndex + oldValue.Length);
            startIndex += newValue.Length;
        }
        return originalString;
    }
}

public static class StringExt
{
    public static string Truncate(this string value, int maxLength)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return value.Length <= maxLength ? value : value.Substring(0, maxLength);
    }

    public static string Truncate(this string value, int maxLength, string truncationSuffix)
    {
        if (String.IsNullOrEmpty(value)) return value;

        return value.Length > maxLength
            ? value.Substring(0, maxLength) + truncationSuffix
            : value;
    }
}