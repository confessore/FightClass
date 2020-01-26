using FightClass.Vanilla.Warlock.Services.Interfaces;
using TreeTask;

namespace FightClass.Vanilla.Warlock.TTasks
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
