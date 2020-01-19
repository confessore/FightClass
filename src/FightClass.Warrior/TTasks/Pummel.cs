using FightClass.Warrior.Helpers;
using FightClass.Warrior.Services.Interfaces;
using TreeTask;
using wManager.Wow.Class;
using wManager.Wow.ObjectManager;

namespace FightClass.Warrior.TTasks
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

        public override async void Execute()
        {
            if (await StanceHelper.HasBerserkerStance)
                spellService.Pummel.Launch();
            else
                await StanceHelper.CastBerserkerStanceAsync();
        }
    }
}
