using wManager.Wow.Class;

namespace FightClass.Warrior.Services.Interfaces
{
    internal interface ISpellService
    {
        Spell Charge { get; }
        Spell Bloodrage { get; }
        Spell BattleShout { get; }
        Spell BerserkerStance { get; }
        Spell Intercept { get; }
        Spell Pummel { get; }
        Spell Bloodthirst { get; }
        Spell MortalStrike { get; }
        Spell ShieldSlam { get; }
        Spell Whirlwind { get; }
        Spell HeroicStrike { get; }
        Spell SunderArmor { get; }
        Spell Execute { get; }
    }
}
