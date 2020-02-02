using FightClass.Wotlk.Shaman.Enhancement.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Shaman.Enhancement.TTasks
{
    internal class FeralSpirit : TTask
    {
        readonly ISpellService spellService;

        public FeralSpirit(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 105;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && ObjectManager.Target != null
                && spellService.FeralSpirit.KnownSpell
                && spellService.FeralSpirit.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.FeralSpirit.Launch();
        }
    }
}
