using FightClass.Vanilla.Warlock.Services.Interfaces;
using TreeTask;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace FightClass.Vanilla.Warlock.TTasks
{
    internal class SummonVoidwalker : TTask
    {
        readonly ISpellService spellService;

        public SummonVoidwalker(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 10000;

        public override bool Activate()
        {
            return !ObjectManager.Me.InCombat
                && !ObjectManager.Pet.IsValid
                && spellService.SummonVoidwalker.KnownSpell
                && spellService.SummonVoidwalker.IsSpellUsable;
        }

        public override void Execute()
        {
            if (spellService.SummonVoidwalker.CastTime > 0)
                MovementManager.StopMoveTo(false, Usefuls.Latency + 11000);
            spellService.SummonVoidwalker.Launch(true);
        }
    }
}
