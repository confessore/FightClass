using FightClass.Vanilla.Warrior.Helpers;
using FightClass.Vanilla.Warrior.Services.Interfaces;
using TreeTask;
using wManager.Wow.Class;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace FightClass.Vanilla.Warrior.TTasks
{
    internal class BerserkerStance : TTask
    {
        readonly ISpellService spellService;

        public BerserkerStance(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 5000;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && spellService.BerserkerStance.KnownSpell
                && !StanceHelper.HasBerserkerStance.GetAwaiter().GetResult();
        }

        public override async void Execute()
        {
            await StanceHelper.CastBerserkerStanceAsync();
        }
    }
}
