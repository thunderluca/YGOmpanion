using System;

namespace YGOmpanion.Data.Models
{
    public static class CardExtensions
    {
        public static CardType GetCardType(this Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            return (CardType)card.TypeId;
        }

        public static bool IsMagic(this Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            var cardType = card.GetCardType();

            return cardType == CardType.NormalMagic || cardType == CardType.ContinousMagic 
                || cardType == CardType.EquipMagic || cardType == CardType.RapidMagic 
                || cardType == CardType.RitualMagic || cardType == CardType.TerrainMagic;
        }

        public static bool IsTrap(this Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            var cardType = card.GetCardType();

            return cardType == CardType.NormalTrap || cardType == CardType.ContinousTrap || cardType == CardType.CounterTrap;
        }

        public static bool IsMonster(this Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            return !card.IsMagic() && !card.IsTrap();
        }

        public static bool IsEffectMonster(this Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            if (!card.IsMonster()) return false;

            var cardType = card.GetCardType();

            return cardType == CardType.Effect || cardType == CardType.FlipEffect
                || cardType == CardType.FlipTunerEffect || cardType == CardType.FusionEffect
                || cardType == CardType.PendulumEffect || cardType == CardType.RitualEffect
                || cardType == CardType.SynchroEffect || cardType == CardType.SynchroTunerEffect
                || cardType == CardType.TunerEffect || cardType == CardType.XYZEffect || cardType == CardType.XYZPendulumEffect;
        }

        public static bool IsFlipMonster(this Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            if (!card.IsMonster()) return false;

            var cardType = card.GetCardType();

            return cardType == CardType.FlipEffect || cardType == CardType.FlipTunerEffect;
        }

        public static bool IsFusionMonster(this Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            if (!card.IsMonster()) return false;

            var cardType = card.GetCardType();

            return cardType == CardType.Fusion || cardType == CardType.FusionEffect;
        }

        public static bool IsRitualMonster(this Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            if (!card.IsMonster()) return false;

            var cardType = card.GetCardType();

            return cardType == CardType.Ritual || cardType == CardType.RitualEffect;
        }

        public static bool IsSynchroMonster(this Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            if (!card.IsMonster()) return false;

            var cardType = card.GetCardType();

            return cardType == CardType.Synchro || cardType == CardType.SynchroEffect || cardType == CardType.SynchroTunerEffect;
        }

        public static bool IsPendulumMonster(this Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            if (!card.IsMonster()) return false;

            var cardType = card.GetCardType();

            return cardType == CardType.Pendulum || cardType == CardType.PendulumEffect || cardType == CardType.XYZPendulumEffect;
        }

        public static bool IsTuner(this Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            if (!card.IsMonster()) return false;

            var cardType = card.GetCardType();

            return cardType == CardType.Tuner || cardType == CardType.TunerEffect 
                || cardType == CardType.FlipTunerEffect || cardType == CardType.SynchroTunerEffect;
        }

        public static string GetAttribute(this Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            if (card.IsMonster()) return card.Attribute;

            return card.Attribute.Split('/')[card.IsMagic() ? 0 : 1];
        }

        public static string GetCardTypes(this Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            if (!card.IsMonster()) return card.Type;

            return card.Race + "/" + card.Type;
        }

        public static string GetAttack(this Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            if (!card.IsMonster()) return string.Empty;

            return "ATK " + (card.Attack < 0 ? "?" : card.Attack.ToString());
        }

        public static string GetDefense(this Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            if (!card.IsMonster()) return string.Empty;

            return "DEF " + (card.Defense < 0 ? "?" : card.Defense.ToString());
        }
    }
}
