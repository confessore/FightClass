using FightClass.Wotlk.Shaman.Enhancement.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Shaman.Enhancement.TTasks
{
    internal class LavaLash : TTask
    {
        readonly ISpellService spellService;

        public LavaLash(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 103;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && ObjectManager.Target != null
                && spellService.LavaLash.KnownSpell
                && spellService.LavaLash.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.LavaLash.Launch();
        }
    }
}
