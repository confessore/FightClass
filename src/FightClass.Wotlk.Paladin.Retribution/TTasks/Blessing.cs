using FightClass.Wotlk.Paladin.Retribution.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Paladin.Retribution.TTasks
{
    internal class Blessing : TTask
    {
        readonly ISpellService spellService;

        public Blessing(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 10000;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && spellService.BlessingOfMight.KnownSpell
                && spellService.BlessingOfMight.IsSpellUsable
                && !spellService.BlessingOfMight.HaveBuff;
        }

        public override void Execute()
        {
            spellService.BlessingOfMight.Launch();
        }
    }
}
