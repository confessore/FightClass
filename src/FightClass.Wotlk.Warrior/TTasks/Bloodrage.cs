using FightClass.Wotlk.Warrior.Services.Interfaces;
using TreeTask;
using wManager.Wow.Class;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Warrior.TTasks
{
    internal class Bloodrage : TTask
    {
        readonly ISpellService spellService;

        public Bloodrage(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 1001;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && spellService.Bloodrage.KnownSpell
                && spellService.Bloodrage.IsSpellUsable
                && !spellService.Bloodrage.HaveBuff;
        }

        public override void Execute()
        {
            spellService.Bloodrage.Launch();
        }
    }
}
