﻿using FightClass.Vanilla.Warrior.Helpers;
using FightClass.Vanilla.Warrior.Services.Interfaces;
using TreeTaskSharp;
using wManager.Wow.ObjectManager;

namespace FightClass.Vanilla.Warrior.TreeTasks
{
    internal class Charge : TreeTask
    {
        readonly ISpellService spellService;

        public Charge(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 5001;

        public override bool Activate()
        {
            return !ObjectManager.Me.InCombat
                && spellService.Charge.KnownSpell
                && ObjectManager.Target.GetDistance > 8f;
        }

        public override async void Execute()
        {
            if (await StanceHelper.HasBattleStance)
                spellService.Charge.Launch();
            else
                await StanceHelper.CastBattleStanceAsync();
        }
    }
}
