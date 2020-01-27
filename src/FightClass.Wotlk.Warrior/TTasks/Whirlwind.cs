using FightClass.Wotlk.Warrior.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Warrior.TTasks
{
    internal class Whirlwind : TTask
    {
        readonly ISpellService spellService;

        public Whirlwind(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 99;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && ObjectManager.Target != null
                && ObjectManager.Me.Rage > 24
                && ObjectManager.Target.HealthPercent > 20
                && spellService.Whirlwind.KnownSpell
                && spellService.Whirlwind.IsSpellUsable
                && !spellService.Bloodthirst.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.Whirlwind.Launch();
        }
    }
}
