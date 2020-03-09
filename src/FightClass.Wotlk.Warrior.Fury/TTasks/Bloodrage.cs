using FightClass.Wotlk.Warrior.Fury.Services.Interfaces;
using TreeTaskSharp;
using wManager.Wow.Class;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Warrior.Fury.TreeTasks
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
