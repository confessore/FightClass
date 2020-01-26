using wManager.Wow.Class;

namespace FightClass.Wotlk.Paladin.Services.Interfaces
{
    internal interface ISpellService
    {
        Spell SealOfRighteousness { get; }
        Spell BlessingOfMight { get; }
        Spell JudgementOfLight { get; }
        Spell JudgementOfWisdom { get; }
        Spell SealOfCommand { get; }
        Spell HolyLight { get; }
        Spell FlashOfLight { get; }
        Spell ArcaneTorrent { get; }
        Spell Consecration { get; }
        Spell Replenishment { get; }
        Spell TheArtOfWar { get; }
        Spell Exorcism { get; }
        Spell CrusaderStrike { get; }
        Spell DivineStorm { get; }
        Spell HammerOfWrath { get; }
        Spell HolyWrath { get; }
    }
}
