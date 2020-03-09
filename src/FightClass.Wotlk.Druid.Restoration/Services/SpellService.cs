using FightClass.Wotlk.Druid.Restoration.Services.Interfaces;
using wManager.Wow.Class;

namespace FightClass.Wotlk.Druid.Restoration.Services
{
    internal class SpellService : ISpellService
    {
        public Spell Rejuvenation => new Spell("Rejuvenation");
        public Spell Regrowth => new Spell("Regrowth");
        public Spell Nourish => new Spell("Nourish");
        public Spell Swiftmend => new Spell("Swiftmend");
        public Spell Innervate => new Spell("Innervate");
        public Spell WildGrowth => new Spell("Wild Growth");
    }
}
