using FightClass.Wotlk.Warrior.Fury.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Warrior.Fury.TTasks
{
    internal class VictoryRush : TTask
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
