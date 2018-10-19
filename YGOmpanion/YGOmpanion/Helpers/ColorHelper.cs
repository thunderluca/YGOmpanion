using Xamarin.Forms;

namespace YGOmpanion.Helpers
{
    public static class ColorHelper
    {
        public static Color GetBottomBackgroundColor(Data.Models.CardType cardType)
        {
            switch (cardType)
            {
                case Data.Models.CardType.Normal:
                    return Color.FromHex("FFDFBD66");
                case Data.Models.CardType.Effect:
                case Data.Models.CardType.FlipEffect:
                case Data.Models.CardType.FlipTunerEffect:
                case Data.Models.CardType.TunerEffect:
                case Data.Models.CardType.Toon:
                    return Color.FromHex("FFBC7D52");
                case Data.Models.CardType.Fusion:
                case Data.Models.CardType.FusionEffect:
                    return Color.FromHex("FFA058AA");
                case Data.Models.CardType.Ritual:
                case Data.Models.CardType.RitualEffect:
                    return Color.FromHex("FF5C9AC3");
                //case Data.Models.CardType.Link:
                //    return Color.FromHex("FF0755A0");
                case Data.Models.CardType.Pendulum:
                case Data.Models.CardType.PendulumEffect:
                    return Color.FromHex("FF018E76");
                case Data.Models.CardType.Synchro:
                case Data.Models.CardType.SynchroEffect:
                case Data.Models.CardType.SynchroTunerEffect:
                    return Color.FromHex("FFD4D4D4");
                case Data.Models.CardType.XYZ:
                case Data.Models.CardType.XYZEffect:
                case Data.Models.CardType.XYZPendulumEffect:
                    return Color.FromHex("FF0A0C0B");
                case Data.Models.CardType.NormalMagic:
                case Data.Models.CardType.ContinousMagic:
                case Data.Models.CardType.EquipMagic:
                case Data.Models.CardType.RapidMagic:
                case Data.Models.CardType.RitualMagic:
                case Data.Models.CardType.TerrainMagic:
                    return Color.FromHex("FF589085");
                case Data.Models.CardType.NormalTrap:
                case Data.Models.CardType.ContinousTrap:
                case Data.Models.CardType.CounterTrap:
                    return Color.FromHex("FFA44684");
                default:
                    return Color.White;
            }
        }

        public static Color GetTopBackgroundColor(Data.Models.CardType cardType)
        {
            switch (cardType)
            {
                case Data.Models.CardType.Normal:
                    return Color.FromHex("FFDFBD66");
                case Data.Models.CardType.Effect:
                case Data.Models.CardType.FlipEffect:
                case Data.Models.CardType.FlipTunerEffect:
                case Data.Models.CardType.TunerEffect:
                case Data.Models.CardType.Toon:
                    return Color.FromHex("FFBC7D52");
                case Data.Models.CardType.Fusion:
                case Data.Models.CardType.FusionEffect:
                    return Color.FromHex("FFA058AA");
                case Data.Models.CardType.Ritual:
                case Data.Models.CardType.RitualEffect:
                    return Color.FromHex("FF5C9AC3");
                //case Data.Models.CardType.Link:
                //    return Color.FromHex("FF0755A0");
                case Data.Models.CardType.Pendulum:
                case Data.Models.CardType.PendulumEffect:
                    return Color.FromHex("FFBF7C50");
                case Data.Models.CardType.Synchro:
                case Data.Models.CardType.SynchroEffect:
                case Data.Models.CardType.SynchroTunerEffect:
                    return Color.FromHex("FFD4D4D4");
                case Data.Models.CardType.XYZ:
                case Data.Models.CardType.XYZEffect:
                case Data.Models.CardType.XYZPendulumEffect:
                    return Color.FromHex("FF0A0C0B");
                case Data.Models.CardType.NormalMagic:
                case Data.Models.CardType.ContinousMagic:
                case Data.Models.CardType.EquipMagic:
                case Data.Models.CardType.RapidMagic:
                case Data.Models.CardType.RitualMagic:
                case Data.Models.CardType.TerrainMagic:
                    return Color.FromHex("FF589085");
                case Data.Models.CardType.NormalTrap:
                case Data.Models.CardType.ContinousTrap:
                case Data.Models.CardType.CounterTrap:
                    return Color.FromHex("FFA44684");
                default:
                    return Color.White;
            }
        }

        public static Color GetForegroundColor(Data.Models.CardType cardType)
        {
            switch (cardType)
            {
                case Data.Models.CardType.Normal:
                    return Color.Black;
                case Data.Models.CardType.Effect:
                case Data.Models.CardType.FlipEffect:
                case Data.Models.CardType.FlipTunerEffect:
                case Data.Models.CardType.TunerEffect:
                case Data.Models.CardType.Toon:
                    return Color.Black;
                case Data.Models.CardType.Fusion:
                case Data.Models.CardType.FusionEffect:
                    return Color.Black;
                case Data.Models.CardType.Ritual:
                case Data.Models.CardType.RitualEffect:
                    return Color.Black;
                //case Data.Models.CardType.Link:
                //    return Color.Black;
                case Data.Models.CardType.Pendulum:
                case Data.Models.CardType.PendulumEffect:
                    return Color.Black;
                case Data.Models.CardType.Synchro:
                case Data.Models.CardType.SynchroEffect:
                case Data.Models.CardType.SynchroTunerEffect:
                    return Color.Black;
                case Data.Models.CardType.XYZ:
                case Data.Models.CardType.XYZEffect:
                case Data.Models.CardType.XYZPendulumEffect:
                    return Color.White;
                case Data.Models.CardType.NormalMagic:
                case Data.Models.CardType.ContinousMagic:
                case Data.Models.CardType.EquipMagic:
                case Data.Models.CardType.RapidMagic:
                case Data.Models.CardType.RitualMagic:
                case Data.Models.CardType.TerrainMagic:
                    return Color.Black;
                case Data.Models.CardType.NormalTrap:
                case Data.Models.CardType.ContinousTrap:
                case Data.Models.CardType.CounterTrap:
                    return Color.Black;
                default:
                    return Color.Black;
            }
        }
    }
}
