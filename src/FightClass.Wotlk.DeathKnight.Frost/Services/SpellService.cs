using FightClass.Wotlk.Shaman.Services.Interfaces;
using wManager.Wow.Class;

namespace FightClass.Wotlk.Shaman.Services
{
    internal class SpellService : ISpellService
    {
        public Spell BloodFury => new Spell("Blood Fury");
        public Spell DeathGrip => new Spell("Death Grip");
        public Spell IcyTouch => new Spell("Icy Touch");
        public Spell PlagueStrike => new Spell("Plague Strike");
        public Spell BloodStrike => new Spell("Blood Strike");
        public Spell DeathCoil => new Spell("Death Coil");
        public Spell Obliterate => new Spell("Obliterate");
        public Spell FrostStrike => new Spell("Frost Strike");
        public Spell HornOfWinter => new Spell("Horn of Winter");
        public Spell FreezingFog => new Spell("Freezing Fog");
        public Spell HowlingBlast => new Spell("Howling Blast");
        public Spell BloodTap => new Spell("Blood Tap");
        public Spell EmpoweredRuneWeapon => new Spell("Empowered Rune Weapon");
        public Spell UnbreakableArmor => new Spell("Unbreakable Armor");
        public Spell MindFreeze => new Spell("Mind Freeze");
    }
}
