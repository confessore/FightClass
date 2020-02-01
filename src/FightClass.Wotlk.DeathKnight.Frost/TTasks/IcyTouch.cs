using FightClass.Wotlk.Shaman.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.DeathKnight.Frost.TTasks
{
    internal class IcyTouch : TTask
    {
        readonly ISpellService spellService;

        public IcyTouch(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 10000;

        public override bool Activate()
        {
            return ObjectManager.Target != null
                && spellService.IcyTouch.KnownSpell
                && spellService.IcyTouch.IsSpellUsable
                && !ObjectManager.Target.HaveBuff("Frost Fever");
        }

        public override void Execute()
        {
            spellService.IcyTouch.Launch();
        }
    }
}
