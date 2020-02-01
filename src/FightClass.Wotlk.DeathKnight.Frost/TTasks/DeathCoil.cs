using FightClass.Wotlk.Shaman.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.DeathKnight.Frost.TTasks
{
    internal class DeathCoil : TTask
    {
        readonly ISpellService spellService;

        public DeathCoil(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => -1;

        public override bool Activate()
        {
            return ObjectManager.Target != null
                && spellService.DeathCoil.KnownSpell
                && spellService.DeathCoil.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.DeathCoil.Launch();
        }
    }
}
