using FightClass.Vanilla.Warrior.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Vanilla.Warrior.TTasks
{
    internal class MortalStrike : TTask
    {
        readonly ISpellService spellService;

        public MortalStrike(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 100;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && ObjectManager.Target != null
                && ObjectManager.Me.Rage > 29
                && ObjectManager.Target.HealthPercent > 20
                && spellService.MortalStrike.KnownSpell
                && spellService.MortalStrike.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.MortalStrike.Launch();
        }
    }
}
