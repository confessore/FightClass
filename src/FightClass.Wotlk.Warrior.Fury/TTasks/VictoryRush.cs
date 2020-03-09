using FightClass.Wotlk.Warrior.Fury.Services.Interfaces;
using TreeTaskSharp;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Warrior.Fury.TreeTasks
{
    internal class VictoryRush : TreeTask
    {
        readonly ISpellService spellService;

        public VictoryRush(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 1000;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && ObjectManager.Target != null
                && spellService.VictoryRush.KnownSpell
                && spellService.VictoryRush.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.VictoryRush.Launch();
        }
    }
}
