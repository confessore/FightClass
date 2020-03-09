using FightClass.Wotlk.Warrior.Fury.Services.Interfaces;
using TreeTaskSharp;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Warrior.Fury.TreeTasks
{
    internal class BerserkerStance : TreeTask
    {
        readonly ISpellService spellService;

        public BerserkerStance(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 5000;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && spellService.BerserkerStance.KnownSpell
                && spellService.BerserkerStance.IsSpellUsable
                && !spellService.BerserkerStance.HaveBuff;
        }

        public override void Execute()
        {
            spellService.BerserkerStance.Launch();
        }
    }
}
