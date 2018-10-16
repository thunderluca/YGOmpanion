using FileHelpers;
using Newtonsoft.Json;

namespace YGOmpanion.Data.Models
{
    [DelimitedRecord(",")]
    [IgnoreFirst]
    [IgnoreEmptyLines]
    public class CardDataRow
    {
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string CardName;
        
        public string Attack;
        
        public string Attribute;
        
        public string Defense;

        [FieldConverter(ConverterKind.Boolean)]
        public bool HasMaterials;

        [FieldConverter(ConverterKind.Boolean)]
        public bool HasNameCondition;

        [FieldConverter(ConverterKind.Boolean)]
        public bool IsExtraDeck;

        [FieldConverter(ConverterKind.Boolean)]
        public bool IsFusion;

        [FieldConverter(ConverterKind.Boolean)]
        public bool IsLink;

        [FieldConverter(ConverterKind.Boolean)]
        public bool IsPendulum;

        [FieldConverter(ConverterKind.Boolean)]
        public bool IsSynchro;

        [FieldConverter(ConverterKind.Boolean)]
        public bool IsXyz;

        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string LinkMarkers;

        [FieldHidden]
        public string[] CardLinkMarkers
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.LinkMarkers)) return new string[0];

                return JsonConvert.DeserializeObject<string[]>(this.LinkMarkers.Trim());
            }
        }

        [FieldNullValue(uint.MinValue)]
        public uint? LinkNumber;

        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string Materials;

        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string MonsterTypes;

        [FieldHidden]
        public string[] CardMonsterTypes
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.MonsterTypes)) return new string[0];

                return JsonConvert.DeserializeObject<string[]>(this.MonsterTypes.Trim());
            }
        }

        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string NameCondition;
        
        public string Number;

        [FieldNullValue(uint.MinValue)]
        public uint? PendulumLeft;

        [FieldNullValue(uint.MinValue)]
        public uint? PendulumRight;

        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string PendulumText;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted)]
        public string Releases;
        
        public string Type;

        [FieldNullValue(uint.MinValue)]
        public uint? Stars;

        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string Text;

        [FieldHidden]
        public CardBrandRelease CardReleases
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.Releases)) return null;

                return JsonConvert.DeserializeObject<CardBrandRelease>(this.Releases.Trim());
            }
        }
    }
}
