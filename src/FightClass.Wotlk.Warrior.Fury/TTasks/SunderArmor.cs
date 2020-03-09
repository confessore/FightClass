using FightClass.Wotlk.Warrior.Fury.Services.Interfaces;
using TreeTaskSharp;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Warrior.Fury.TreeTasks
{
    internal class SunderArmor : TreeTask
    {
        readonly ISpellService spellService;

        public SunderArmor(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 101;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && ObjectManager.Target != null
                && ObjectManager.Me.Rage > 59
                && spellService.SunderArmor.KnownSpell
                && spellService.SunderArmor.IsSpellUsable
                && !spellService.Bloodthirst.IsSpellUsable
                && !spellService.MortalStrike.IsSpellUsable
                && !spellService.ShieldSlam.IsSpellUsable
                && !spellService.Whirlwind.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.SunderArmor.Launch();
        }
    }
}
