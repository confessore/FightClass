using FightClass.Wotlk.Warrior.Fury.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Warrior.Fury.TTasks
{
    internal class BattleShout : TTask
    {
        readonly ISpellService spellService;

        public BattleShout(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 1002;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && ObjectManager.Me.Rage > 9
                && spellService.BattleShout.KnownSpell
                && spellService.BattleShout.IsSpellUsable
                && !spellService.BattleShout.HaveBuff
                && !ObjectManager.Me.Silenced;
        }

        public override void Execute()
        {
            spellService.BattleShout.Launch();
        }
    }
}
