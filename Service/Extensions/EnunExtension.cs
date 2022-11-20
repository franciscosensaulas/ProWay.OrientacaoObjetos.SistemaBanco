namespace Service.Extensions
{
    public static class EnunExtension
    {
        public static int ToInt(this Enum enumValue)
        {
            return Convert.ToInt32(enumValue);
        }
    }
}
