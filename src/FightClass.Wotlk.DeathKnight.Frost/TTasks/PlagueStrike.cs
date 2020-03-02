using FightClass.Wotlk.DeathKnight.Frost.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.DeathKnight.Frost.TTasks
{
    internal class PlagueStrike : TTask
    {
        readonly ISpellService spellService;

        public PlagueStrike(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 9000;

        public override bool Activate()
        {
            return ObjectManager.Target != null
                && spellService.PlagueStrike.KnownSpell
                && spellService.PlagueStrike.IsSpellUsable
                && !ObjectManager.Target.HaveBuff("Blood Plague");
        }

        public override void Execute()
        {
            spellService.PlagueStrike.Launch();
        }
    }
}
