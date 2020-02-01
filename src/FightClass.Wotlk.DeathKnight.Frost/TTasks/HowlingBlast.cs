using FightClass.Wotlk.Shaman.Services.Interfaces;
using TreeTask;

namespace FightClass.Wotlk.DeathKnight.Frost.TTasks
{
    internal class HowlingBlast : TTask
    {
        readonly ISpellService spellService;

        public HowlingBlast(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 14000;

        public override bool Activate()
        {
            return spellService.HowlingBlast.KnownSpell
                && spellService.HowlingBlast.IsSpellUsable
                && spellService.FreezingFog.HaveBuff;
        }

        public override void Execute()
        {
            spellService.HowlingBlast.Launch();
        }
    }
}
