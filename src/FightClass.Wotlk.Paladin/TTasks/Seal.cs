using FightClass.Wotlk.Paladin.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Paladin.TTasks
{
    internal class Seal : TTask
    {
        readonly ISpellService spellService;

        public Seal(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 10001;

        public override bool Activate()
        {
            return (spellService.SealOfRighteousness.KnownSpell
                || spellService.SealOfCommand.KnownSpell
                || spellService.SealOfCorruption.KnownSpell
                || spellService.SealOfVengeance.KnownSpell)
                && (spellService.SealOfRighteousness.IsSpellUsable
                || spellService.SealOfCommand.IsSpellUsable
                || spellService.SealOfCorruption.IsSpellUsable
                || spellService.SealOfVengeance.IsSpellUsable)
                && (!spellService.SealOfRighteousness.HaveBuff
                && !spellService.SealOfCommand.HaveBuff
                && !spellService.SealOfCorruption.HaveBuff
                && !spellService.SealOfVengeance.HaveBuff);
        }

        public override void Execute()
        {
            if (spellService.SealOfCorruption.KnownSpell)
                spellService.SealOfCorruption.Launch();
            else if (spellService.SealOfVengeance.KnownSpell)
                spellService.SealOfVengeance.Launch();
            else if (spellService.SealOfCommand.KnownSpell)
                spellService.SealOfCommand.Launch();
            else
                spellService.SealOfRighteousness.Launch();
        }
    }
}
