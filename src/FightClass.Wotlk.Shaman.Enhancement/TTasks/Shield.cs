using FightClass.Wotlk.Shaman.Enhancement.Services.Interfaces;
using TreeTask;

namespace FightClass.Wotlk.Shaman.Enhancement.TTasks
{
    internal class Shield : TTask
    {
        readonly ISpellService spellService;

        public Shield(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 998;

        public override bool Activate()
        {
            return spellService.LightningShield.KnownSpell
                && spellService.LightningShield.IsSpellUsable
                && !spellService.LightningShield.HaveBuff;
        }

        public override void Execute()
        {
            spellService.LightningShield.Launch();
        }
    }
}
