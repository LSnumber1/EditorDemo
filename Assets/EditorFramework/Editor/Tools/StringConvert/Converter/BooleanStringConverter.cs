namespace EditorFramework
{
    public class BooleanStringConverter:StringConverter<bool>
    {
        public override bool tryConvert(string self, out bool result)
        {
            if (bool.TryParse(self, out result))
            {
                return true;
            }

            return false;
        }
    }
}