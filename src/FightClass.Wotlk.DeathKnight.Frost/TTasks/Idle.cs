using TreeTask;

namespace FightClass.Wotlk.DeathKnight.Frost.TTasks
{
    internal class Idle : TTask
    {
        public override int Priority => 0;

        public override bool Activate() =>
            true;

        public override void Execute()
        {

        }
    }
}
