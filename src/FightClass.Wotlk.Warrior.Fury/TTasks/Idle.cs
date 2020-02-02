using FightClass.Wotlk.Warrior.Fury.Services.Interfaces;
using TreeTask;

namespace FightClass.Wotlk.Warrior.Fury.TTasks
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
