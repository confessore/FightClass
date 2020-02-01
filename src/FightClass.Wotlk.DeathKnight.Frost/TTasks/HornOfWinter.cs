using FightClass.Wotlk.Shaman.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.DeathKnight.Frost.TTasks
{
    internal class HornOfWinter : TTask
    {
        readonly ISpellService spellService;

        public HornOfWinter(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 16000;

        public override bool Activate()
        {
            return spellService.HornOfWinter.KnownSpell
                && spellService.HornOfWinter.IsSpellUsable
                && !spellService.HornOfWinter.HaveBuff;
        }

        public override void Execute()
        {
            spellService.HornOfWinter.Launch();
        }
    }
}
