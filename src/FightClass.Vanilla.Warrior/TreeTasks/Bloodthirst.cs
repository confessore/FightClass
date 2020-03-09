using FightClass.Vanilla.Warrior.Services.Interfaces;
using TreeTaskSharp;
using wManager.Wow.ObjectManager;

namespace FightClass.Vanilla.Warrior.TreeTasks
{
    internal class Bloodthirst : TreeTask
    {
        readonly ISpellService spellService;

        public Bloodthirst(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 100;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && ObjectManager.Target != null
                && ObjectManager.Me.Rage > 29
                && ObjectManager.Target.HealthPercent > 20
                && spellService.Bloodthirst.KnownSpell
                && spellService.Bloodthirst.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.Bloodthirst.Launch();
        }
    }
}
