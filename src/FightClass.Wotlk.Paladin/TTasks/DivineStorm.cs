using FightClass.Wotlk.Paladin.Services.Interfaces;
using TreeTask;

namespace FightClass.Wotlk.Paladin.TTasks
{
    internal class DivineStorm : TTask
    {
        readonly ISpellService spellService;

        public DivineStorm(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 7000;

        public override bool Activate()
        {
            return spellService.DivineStorm.KnownSpell
                && spellService.DivineStorm.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.DivineStorm.Launch();
        }
    }
}
