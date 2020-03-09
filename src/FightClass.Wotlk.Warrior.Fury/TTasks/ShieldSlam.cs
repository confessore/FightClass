using FightClass.Wotlk.Warrior.Fury.Services.Interfaces;
using TreeTaskSharp;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Warrior.Fury.TreeTasks
{
    internal class ShieldSlam : TreeTask
    {
        readonly ISpellService spellService;

        public ShieldSlam(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 100;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && ObjectManager.Target != null
                && ObjectManager.Me.Rage > 19
                && ObjectManager.Target.HealthPercent > 20
                && spellService.ShieldSlam.KnownSpell
                && spellService.ShieldSlam.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.ShieldSlam.Launch();
        }
    }
}
