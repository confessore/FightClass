using FightClass.Wotlk.Paladin.Services.Interfaces;
using TreeTask;

namespace FightClass.Wotlk.Paladin.TTasks
{
    internal class Consecration : TTask
    {
        readonly ISpellService spellService;

        public Consecration(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 6000;

        public override bool Activate()
        {
            return spellService.Replenishment.HaveBuff
                && spellService.Consecration.KnownSpell
                && spellService.Consecration.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.Consecration.Launch();
        }
    }
}
