using FightClass.Wotlk.Shaman.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.DeathKnight.Frost.TTasks
{
    internal class MindFreeze : TTask
    {
        readonly ISpellService spellService;

        public MindFreeze(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 20000;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && ObjectManager.Target != null
                && spellService.MindFreeze.KnownSpell
                && spellService.MindFreeze.IsSpellUsable
                && ObjectManager.Target.CastingSpellId != 0;
        }

        public override void Execute()
        {
            spellService.MindFreeze.Launch();
        }
    }
}
