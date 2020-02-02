using FightClass.Wotlk.Warrior.Fury.Services.Interfaces;
using wManager.Wow.Class;

namespace FightClass.Wotlk.Warrior.Fury.Services
{
    internal class SpellService : ISpellService
    {
        public Spell Charge => new Spell("Charge");
        public Spell BattleShout => new Spell("Battle Shout");
        public Spell Bloodrage => new Spell("Bloodrage");
        public Spell BattleStance => new Spell("Battle Stance");
        public Spell BerserkerStance => new Spell("Berserker Stance");
        public Spell Intercept => new Spell("Intercept");
        public Spell Pummel => new Spell("Pummel");
        public Spell Bloodthirst => new Spell("Bloodthirst");
        public Spell MortalStrike => new Spell("Mortal Strike");
        public Spell ShieldSlam => new Spell("Shield Slam");
        public Spell Whirlwind => new Spell("Whirlwind");
        public Spell HeroicStrike => new Spell("Heroic Strike");
        public Spell SunderArmor => new Spell("Sunder Armor");
        public Spell Execute => new Spell("Execute");
        public Spell VictoryRush => new Spell("Victory Rush");
        public Spell Bloodsurge => new Spell("Slam!");
        public Spell Slam => new Spell("Slam");
    }
}
