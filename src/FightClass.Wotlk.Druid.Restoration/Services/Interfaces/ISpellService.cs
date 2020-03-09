using wManager.Wow.Class;

namespace FightClass.Wotlk.Druid.Restoration.Services.Interfaces
{
    internal interface ISpellService
    {
        Spell Rejuvenation { get; }
        Spell Regrowth { get; }
        Spell Nourish { get; }
        Spell Swiftmend { get; }
        Spell Innervate { get; }
        Spell WildGrowth { get; }
    }
}
