using FightClass.Warrior.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Warrior.TTasks
{
    internal class X : TTask
    {
        readonly ISpellService spellService;

        public X(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 999;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && ObjectManager.Target != null
                && ObjectManager.Me.Rage > 9
                && ObjectManager.Target.HealthPercent <= 20
                && spellService.Execute.KnownSpell
                && spellService.Execute.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.Execute.Launch();
        }
    }
}
