using FightClass.Wotlk.Paladin.Services.Interfaces;
using TreeTask;

namespace FightClass.Wotlk.Paladin.TTasks
{
    internal class HolyWrath : TTask
    {
        readonly ISpellService spellService;

        public HolyWrath(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 4000;

        public override bool Activate()
        {
            return spellService.HolyWrath.KnownSpell
                && spellService.HolyWrath.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.HolyWrath.Launch();
        }
    }
}
