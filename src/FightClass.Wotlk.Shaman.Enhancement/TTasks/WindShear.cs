using FightClass.Wotlk.Shaman.Enhancement.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Shaman.Enhancement.TTasks
{
    internal class WindShear : TTask
    {
        readonly ISpellService spellService;

        public WindShear(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 9999;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && ObjectManager.Target != null
                && spellService.WindShear.KnownSpell
                && spellService.WindShear.IsSpellUsable
                && ObjectManager.Target.CastingSpellId != 0;
        }

        public override void Execute()
        {
            spellService.WindShear.Launch();
        }
    }
}
