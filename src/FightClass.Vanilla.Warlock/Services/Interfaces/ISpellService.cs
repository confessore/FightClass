using wManager.Wow.Class;

namespace FightClass.Vanilla.Warlock.Services.Interfaces
{
    internal interface ISpellService
    {
        Spell ShadowBolt { get; }
        Spell SummonVoidwalker { get; }
    }
}
