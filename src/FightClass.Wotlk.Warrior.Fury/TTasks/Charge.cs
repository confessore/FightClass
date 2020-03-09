using FightClass.Wotlk.Warrior.Fury.Services.Interfaces;
using TreeTaskSharp;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Warrior.Fury.TreeTasks
{
    internal class Charge : TreeTask
    {
        readonly ISpellService spellService;

        public Charge(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 5001;

        public override bool Activate()
        {
            return !ObjectManager.Me.InCombat
                && spellService.Charge.KnownSpell
                && ObjectManager.Target.GetDistance > 8f;
        }

        public override void Execute()
        {
            if (spellService.BattleStance.HaveBuff)
                spellService.Charge.Launch();
            else
                spellService.BattleStance.Launch();
        }
    }
}
