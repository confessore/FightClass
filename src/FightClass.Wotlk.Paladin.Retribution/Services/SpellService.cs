using FightClass.Wotlk.Paladin.Retribution.Services.Interfaces;
using wManager.Wow.Class;

namespace FightClass.Wotlk.Paladin.Retribution.Services
{
    internal class SpellService : ISpellService
    {
        public Spell SealOfRighteousness => new Spell("Seal of Righteousness");
        public Spell BlessingOfMight => new Spell("Blessing of Might");
        public Spell JudgementOfLight => new Spell("Judgement of Light");
        public Spell JudgementOfWisdom => new Spell("Judgement of Wisdom");
        public Spell SealOfCommand => new Spell("Seal of Command");
        public Spell HolyLight => new Spell("Holy Light");
        public Spell FlashOfLight => new Spell("Flash of Light");
        public Spell ArcaneTorrent => new Spell("Arcane Torrent");
        public Spell Consecration => new Spell("Consecration");
        public Spell Replenishment => new Spell("Replenishment");
        public Spell TheArtOfWar => new Spell("The Art of War");
        public Spell Exorcism => new Spell("Exorcism");
        public Spell CrusaderStrike => new Spell("Crusader Strike");
        public Spell DivineStorm => new Spell("Divine Storm");
        public Spell HammerOfWrath => new Spell("Hammer of Wrath");
        public Spell HolyWrath => new Spell("Holy Wrath");
        public Spell SealOfCorruption => new Spell("Seal of Corruption");
        public Spell SealOfVengeance => new Spell("Seal of Vengeance");
    }
}
