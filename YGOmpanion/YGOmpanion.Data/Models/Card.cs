namespace YGOmpanion.Data.Models
{
    public class Card
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long SetCode { get; set; }
        
        public int TypeId { get; set; }

        public string Type { get; set; }

        public int Attack { get; set; }
        
        public int Defense { get; set; }
        
        public int Level { get; set; }

        public string Race { get; set; }
        
        public string Attribute { get; set; }
        
        public string Category { get; set; }
    }
}
