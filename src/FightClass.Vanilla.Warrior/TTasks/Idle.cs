using FightClass.Vanilla.Warrior.Services.Interfaces;
using TreeTask;

namespace FightClass.Vanilla.Warrior.TTasks
{
    internal class Idle : TTask
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
