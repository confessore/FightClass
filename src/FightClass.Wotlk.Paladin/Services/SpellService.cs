using FightClass.Wotlk.Paladin.Services.Interfaces;
using wManager.Wow.Class;

namespace FightClass.Wotlk.Paladin.Services
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
    }
}
