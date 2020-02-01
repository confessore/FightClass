using FightClass.Wotlk.Shaman.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.DeathKnight.Frost.TTasks
{
    internal class FrostStrike : TTask
    {
        readonly ISpellService spellService;

        public FrostStrike(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 7000;

        public override bool Activate()
        {
            return ObjectManager.Target != null
                && spellService.FrostStrike.KnownSpell
                && spellService.FrostStrike.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.FrostStrike.Launch();
        }
    }
}
