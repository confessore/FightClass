using FightClass.Wotlk.Warrior.Fury.Services.Interfaces;
using TreeTaskSharp;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Warrior.Fury.TreeTasks
{
    internal class Pummel : TreeTask
    {
        readonly ISpellService spellService;

        public Pummel(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 10001;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && ObjectManager.Target != null
                && ObjectManager.Me.Rage > 9
                && spellService.Pummel.KnownSpell
                && ObjectManager.Target.CastingSpellId != 0;
        }

        public override void Execute()
        {
            if (!spellService.BerserkerStance.HaveBuff)
                spellService.Pummel.Launch();
            else
                spellService.BerserkerStance.Launch();
        }
    }
}
