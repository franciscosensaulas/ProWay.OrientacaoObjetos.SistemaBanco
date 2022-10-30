namespace Service.Extensions
{
    public static class StringExtension
    {
        public static string Format(this string message, params object[] args) =>
            string.Format(message, args);
    }
}
