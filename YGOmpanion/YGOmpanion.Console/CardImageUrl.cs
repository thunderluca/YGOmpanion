using FileHelpers;

namespace YGOmpanion.Console
{
    [DelimitedRecord(";")]
    public class CardImageUrl
    {
        public int Id;

        public string Url;
    }
}
