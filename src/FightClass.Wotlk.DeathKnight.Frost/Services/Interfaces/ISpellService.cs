using wManager.Wow.Class;

namespace FightClass.Wotlk.DeathKnight.Frost.Services.Interfaces
{
    internal interface ISpellService
    {
        Spell BloodFury { get; }
        Spell DeathGrip { get; }
        Spell IcyTouch { get; }
        Spell PlagueStrike { get; }
        Spell BloodStrike { get; }
        Spell DeathCoil { get; }
        Spell Obliterate { get; }
        Spell FrostStrike { get; }
        Spell HornOfWinter { get; }
        Spell FreezingFog { get; }
        Spell HowlingBlast { get; }
        Spell BloodTap { get; }
        Spell EmpoweredRuneWeapon { get; }
        Spell UnbreakableArmor { get; }
        Spell MindFreeze { get; }
    }
}
