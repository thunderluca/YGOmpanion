using SQLite;

namespace YGOmpanion.Data.Models
{
    [Table("datas")]
    public class CardData
    {
        [Column("id")]
        [PrimaryKey]
        public int Id { get; set; }

        [Column("ot")]
        public int Ot { get; set; }

        [Column("alias")]
        public int Alias { get; set; }

        [Column("setcode")]
        public long SetCode { get; set; }

        [Column("type")]
        public int Type { get; set; }

        [Column("atk")]
        public int Attack { get; set; }

        [Column("def")]
        public int Defense { get; set; }

        [Column("level")]
        public int Level { get; set; }

        [Column("race")]
        public int Race { get; set; }

        [Column("attribute")]
        public int Attribute { get; set; }

        [Column("category")]
        public int Category { get; set; }
    }
}
