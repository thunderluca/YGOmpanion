using SQLite;
using System;

namespace YGOmpanion.Data.Models
{
    [Table("decks")]
    public class Deck
    {
        [Column("id")]
        [PrimaryKey]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("createdon")]
        public DateTime CreatedOn { get; set; }

        [Column("cardscount")]
        public int CardsCount { get; set; }
    }
}
