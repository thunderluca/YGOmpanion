using Newtonsoft.Json.Converters;

namespace YGOmpanion.Data.Converters
{
    internal class CustomDateConverter : IsoDateTimeConverter
    {
        public CustomDateConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
