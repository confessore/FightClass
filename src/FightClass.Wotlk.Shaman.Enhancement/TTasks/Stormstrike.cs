using FightClass.Wotlk.Shaman.Enhancement.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Shaman.Enhancement.TTasks
{
    internal class Stormstrike : TTask
    {
        readonly ISpellService spellService;

        public Stormstrike(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 104;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && ObjectManager.Target != null
                && spellService.Stormstrike.KnownSpell
                && spellService.Stormstrike.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.Stormstrike.Launch();
        }
    }
}
