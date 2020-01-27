using FightClass.Wotlk.Warrior.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Warrior.TTasks
{
    internal class Pummel : TTask
    {
        readonly ISpellService spellService;

        public Pummel(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 10001;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && ObjectManager.Target != null
                && ObjectManager.Me.Rage > 9
                && spellService.Pummel.KnownSpell
                && ObjectManager.Target.CastingSpellId != 0;
        }

        public override void Execute()
        {
            if (!spellService.BerserkerStance.HaveBuff)
                spellService.Pummel.Launch();
            else
                spellService.BerserkerStance.Launch();
        }
    }
}
