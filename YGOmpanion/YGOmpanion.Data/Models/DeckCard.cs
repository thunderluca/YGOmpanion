using SQLite;

namespace YGOmpanion.Data.Models
{
    [Table("decksCards")]
    public class DeckCard
    {
        [Column("id")]
        [PrimaryKey]
        public int Id { get; set; }

        [Column("deckid")]
        public int DeckId { get; set; }

        [Column("cardid")]
        public int CardId { get; set; }

        [Column("count")]
        public int Count { get; set; }
    }
}
