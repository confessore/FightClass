using FightClass.Wotlk.DeathKnight.Frost.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.DeathKnight.Frost.TTasks
{
    internal class BloodTap : TTask
    {
        readonly ISpellService spellService;

        public BloodTap(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 13000;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && ObjectManager.Target != null
                && spellService.BloodTap.KnownSpell
                && spellService.BloodTap.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.BloodTap.Launch();
        }
    }
}
