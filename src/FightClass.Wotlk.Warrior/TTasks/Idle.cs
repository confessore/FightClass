using FightClass.Wotlk.Warrior.Services.Interfaces;
using TreeTask;

namespace FightClass.Wotlk.Warrior.TTasks
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
