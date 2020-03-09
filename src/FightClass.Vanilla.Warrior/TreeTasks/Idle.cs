using FightClass.Vanilla.Warrior.Services.Interfaces;
using TreeTaskSharp;

namespace FightClass.Vanilla.Warrior.TreeTasks
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
