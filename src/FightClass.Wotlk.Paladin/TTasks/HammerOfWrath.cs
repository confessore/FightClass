using FightClass.Wotlk.Paladin.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Paladin.TTasks
{
    internal class HammerOfWrath : TTask
    {
        readonly ISpellService spellService;

        public HammerOfWrath(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 99999;

        public override bool Activate()
        {
            return ObjectManager.Target.HealthPercent <= 20
                && spellService.HammerOfWrath.KnownSpell
                && spellService.HammerOfWrath.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.HammerOfWrath.Launch();
        }
    }
}
