using FightClass.Wotlk.DeathKnight.Frost.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.DeathKnight.Frost.TTasks
{
    internal class BloodStrike : TTask
    {
        readonly ISpellService spellService;

        public BloodStrike(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 6000;

        public override bool Activate()
        {
            return ObjectManager.Target != null
                && spellService.BloodStrike.KnownSpell
                && spellService.BloodStrike.IsSpellUsable
                && ObjectManager.Target.HaveBuff("Frost Fever")
                && ObjectManager.Target.HaveBuff("Blood Plague");
        }

        public override void Execute()
        {
            spellService.BloodStrike.Launch();
        }
    }
}
