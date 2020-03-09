using FightClass.Vanilla.Warrior.Services.Interfaces;
using TreeTaskSharp;
using wManager.Wow.ObjectManager;

namespace FightClass.Vanilla.Warrior.TreeTasks
{
    internal class Bloodrage : TreeTask
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
