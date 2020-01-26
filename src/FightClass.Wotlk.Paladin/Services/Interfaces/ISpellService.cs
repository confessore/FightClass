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
    }
}
