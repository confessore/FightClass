using FightClass.Vanilla.Warlock.Services.Interfaces;
using wManager.Wow.Class;

namespace FightClass.Vanilla.Warlock.Services
{
    internal class SpellService : ISpellService
    {
        public Spell ShadowBolt => new Spell("Shadow Bolt");
        public Spell SummonVoidwalker => new Spell("Summon Voidwalker");
    }
}
