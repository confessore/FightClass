using FightClass.Wotlk.Warrior.Fury.Services.Interfaces;
using TreeTaskSharp;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Warrior.Fury.TreeTasks
{
    internal class Slam : TreeTask
    {
        readonly ISpellService spellService;

        public Slam(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 998;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && ObjectManager.Target != null
                && spellService.Slam.KnownSpell
                && spellService.Slam.IsSpellUsable
                && spellService.Bloodsurge.HaveBuff;
        }

        public override void Execute()
        {
            spellService.Slam.Launch();
        }
    }
}
