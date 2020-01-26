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
                || spellService.SealOfCommand.KnownSpell)
                && (spellService.SealOfRighteousness.IsSpellUsable
                || spellService.SealOfCommand.IsSpellUsable)
                && (!spellService.SealOfRighteousness.HaveBuff
                && !spellService.SealOfCommand.HaveBuff);
        }

        public override void Execute()
        {
            if (spellService.SealOfCommand.KnownSpell)
                spellService.SealOfCommand.Launch();
            else
                spellService.SealOfRighteousness.Launch();
        }
    }
}
