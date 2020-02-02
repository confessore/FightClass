using FightClass.Wotlk.Shaman.Enhancement.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Shaman.Enhancement.TTasks
{
    internal class ShamanisticRage : TTask
    {
        readonly ISpellService spellService;

        public ShamanisticRage(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 101;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && ObjectManager.Target != null
                && spellService.ShamanisticRage.KnownSpell
                && spellService.ShamanisticRage.IsSpellUsable
                && ObjectManager.Me.ManaPercentage < 50;
        }

        public override void Execute()
        {
            spellService.ShamanisticRage.Launch();
        }
    }
}
