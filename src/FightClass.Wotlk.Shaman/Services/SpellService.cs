using FightClass.Wotlk.Shaman.Services.Interfaces;
using wManager.Wow.Class;

namespace FightClass.Wotlk.Shaman.Services
{
    internal class SpellService : ISpellService
    {
        public Spell RockbiterWeapon => new Spell("Rockbiter Weapon");
        public Spell EarthShock => new Spell("Earth Shock");
        public Spell HealingWave => new Spell("Healing Wave");
        public Spell LesserHealingWave => new Spell("Lesser Healing Wave");
        public Spell LightningShield => new Spell("Lightning Shield");
        public Spell FlameShock => new Spell("Flame Shock");
        public Spell StrengthOfEarthTotem => new Spell("Strength of Earth Totem");
        public Spell StrengthOfEarth => new Spell("Strength of Earth");
        public Spell WindShear => new Spell("Wind Shear");
        public Spell SearingTotem => new Spell("Searing Totem");
        public Spell WindfuryWeapon => new Spell("Windfury Weapon");
        public Spell FlametongueWeapon => new Spell("Flametongue Weapon");
        public Spell WindfuryTotem => new Spell("Windfury Totem");
        public Spell HealingStreamTotem => new Spell("Healing Stream Totem");
        public Spell Stormstrike => new Spell("Stormstrike");
        public Spell LavaLash => new Spell("Lava Lash");
        public Spell MaelstromWeapon => new Spell("Maelstrom Weapon");
        public Spell FeralSpirit => new Spell("Feral Spirit");
        public Spell ShamanisticRage => new Spell("Shamanistic Rage");
        public Spell LightningBolt => new Spell("Lightning Bolt");
    }
}
