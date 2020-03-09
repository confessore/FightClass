using FightClass.Wotlk.Warrior.Fury.Services.Interfaces;
using TreeTaskSharp;

namespace FightClass.Wotlk.Warrior.Fury.TreeTasks
{
    internal class Idle : TreeTask
    {
        readonly ISpellService spellService;

        public Idle(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 0;

        public override bool Activate()
        {
            return true;
        }

        public override void Execute()
        {

        }
    }
}
