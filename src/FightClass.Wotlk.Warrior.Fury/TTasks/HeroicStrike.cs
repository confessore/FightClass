using FightClass.Wotlk.Warrior.Fury.Services.Interfaces;
using TreeTaskSharp;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Warrior.Fury.TreeTasks
{
    internal class HeroicStrike : TreeTask
    {
        readonly ISpellService spellService;

        public HeroicStrike(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 97;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && ObjectManager.Target != null
                && ObjectManager.Me.Rage > 49
                && ObjectManager.Target.HealthPercent > 20
                && spellService.HeroicStrike.IsSpellUsable
                && !spellService.Bloodthirst.IsSpellUsable
                && !spellService.MortalStrike.IsSpellUsable
                && !spellService.ShieldSlam.IsSpellUsable
                && !spellService.Whirlwind.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.HeroicStrike.Launch();
        }
    }
}
