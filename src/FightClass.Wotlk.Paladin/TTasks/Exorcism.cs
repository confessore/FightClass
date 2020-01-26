using FightClass.Wotlk.Paladin.Services.Interfaces;
using TreeTask;

namespace FightClass.Wotlk.Paladin.TTasks
{
    internal class Exorcism : TTask
    {
        readonly ISpellService spellService;

        public Exorcism(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 5000;

        public override bool Activate()
        {
            return spellService.TheArtOfWar.HaveBuff
                && spellService.Exorcism.KnownSpell
                && spellService.Exorcism.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.Exorcism.Launch();
        }
    }
}
