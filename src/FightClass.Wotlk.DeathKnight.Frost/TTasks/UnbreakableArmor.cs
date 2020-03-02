using FightClass.Wotlk.DeathKnight.Frost.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.DeathKnight.Frost.TTasks
{
    internal class UnbreakableArmor : TTask
    {
        readonly ISpellService spellService;

        public UnbreakableArmor(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 12000;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && ObjectManager.Target != null
                && spellService.UnbreakableArmor.KnownSpell
                && spellService.UnbreakableArmor.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.UnbreakableArmor.Launch();
        }
    }
}
