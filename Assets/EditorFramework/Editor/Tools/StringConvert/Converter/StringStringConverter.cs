namespace EditorFramework
{
    public class StringStringConverter : StringConverter<string>
    {
        public override bool tryConvert(string self, out string result)
        {
            result = self;
            return true;
        }
    }
}