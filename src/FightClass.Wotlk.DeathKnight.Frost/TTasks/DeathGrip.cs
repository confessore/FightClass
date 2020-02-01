using FightClass.Wotlk.Shaman.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.DeathKnight.Frost.TTasks
{
    class DeathGrip : TTask
    {
        readonly ISpellService spellService;

        public DeathGrip(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 1000;

        public override bool Activate()
        {
            return ObjectManager.Target != null
                && spellService.DeathGrip.KnownSpell
                && spellService.DeathGrip.IsSpellUsable
                && ObjectManager.Target.GetDistance > 8f;
        }

        public override void Execute()
        {
            spellService.DeathGrip.Launch();
        }
    }
}
