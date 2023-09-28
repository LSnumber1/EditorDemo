namespace EditorFramework
{
    public static class StringConvert
    {
        public static bool TryConvert<T>(this string self, out T t)
        {
            if (StringConverter.Get<T>().tryConvert(self, out t))
            {
                return true;
            }
            return false;
        }
    }
}