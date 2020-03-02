using FightClass.Wotlk.DeathKnight.Frost.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.DeathKnight.Frost.TTasks
{
    internal class BloodFury : TTask
    {
        readonly ISpellService spellService;

        public BloodFury(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 15000;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && ObjectManager.Target != null
                && spellService.BloodFury.KnownSpell
                && spellService.BloodFury.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.BloodFury.Launch();
        }
    }
}
