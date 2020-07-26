namespace HeyYo.Core.App.String
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string content)
        {
            return string.IsNullOrEmpty(content);
        }

        public static bool IsNullOrWhiteSpace(this string content)
        {
            return string.IsNullOrWhiteSpace(content);
        }
    }
}
