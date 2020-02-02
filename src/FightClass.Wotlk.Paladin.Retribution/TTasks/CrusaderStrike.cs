using FightClass.Wotlk.Paladin.Retribution.Services.Interfaces;
using TreeTask;

namespace FightClass.Wotlk.Paladin.Retribution.TTasks
{
    internal class CrusaderStrike : TTask
    {
        readonly ISpellService spellService;

        public CrusaderStrike(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 8000;

        public override bool Activate()
        {
            return spellService.CrusaderStrike.KnownSpell
                && spellService.CrusaderStrike.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.CrusaderStrike.Launch();
        }
    }
}
