﻿using System.ComponentModel.DataAnnotations;

namespace YGOmpanion.Data.Models
{
    public enum CardType : int
    {
        [Display(Name = "Normal Magic")]
        NormalMagic = 2,
        [Display(Name = "Normal Trap")]
        NormalTrap = 4,
        [Display(Name = "Normal")]
        Normal = 17,
        [Display(Name = "Effect")]
        Effect = 33,
        [Display(Name = "Fusion")]
        Fusion = 65,
        [Display(Name = "Fusion/Effect")]
        FusionEffect = 97,
        [Display(Name = "Ritual")]
        Ritual = 129,
        [Display(Name = "Ritual Magic")]
        RitualMagic = 130,
        [Display(Name = "Ritual/Effect")]
        RitualEffect = 161,
        [Display(Name = "Spirit")]
        Spirit = 545,
        [Display(Name = "Union")]
        Union = 1057,
        [Display(Name = "Gemini")]
        Gemini = 2081,
        [Display(Name = "Tuner")]
        Tuner = 4113,
        [Display(Name = "Tuner/Effect")]
        TunerEffect = 4129,
        [Display(Name = "Synchro")]
        Synchro = 8193,
        [Display(Name = "Synchro/Effect")]
        SynchroEffect = 8225,
        [Display(Name = "Synchro/Tuner/Effect")]
        SynchroTunerEffect = 12321,
        [Display(Name = "Token")]
        Token = 16401,
        [Display(Name = "Token")]
        Token2 = 16417,
        [Display(Name = "Rapid Magic")]
        RapidMagic = 65538,
        [Display(Name = "Continous Magic")]
        ContinousMagic = 131074,
        [Display(Name = "Continous Trap")]
        ContinousTrap = 131076,
        [Display(Name = "Equip Magic")]
        EquipMagic = 262146,
        [Display(Name = "Terrain Magic")]
        TerrainMagic = 524290,
        [Display(Name = "Counter Trap")]
        CounterTrap = 1048580,
        [Display(Name = "Flip/Effect")]
        FlipEffect = 2097185,
        [Display(Name = "Flip/Tuner/Effect")]
        FlipTunerEffect = 2101281,
        [Display(Name = "Toon")]
        Toon = 4194337,
        [Display(Name = "XYZ")]
        XYZ = 8388609,
        [Display(Name = "XYZ/Effect")]
        XYZEffect = 8388641,
        [Display(Name = "Pendulum")]
        Pendulum = 16777233,
        [Display(Name = "Pendulum/Effect")]
        PendulumEffect = 16777249,
        [Display(Name = "XYZ/Pendulum/Effect")]
        XYZPendulumEffect = 25165857
    }
}
