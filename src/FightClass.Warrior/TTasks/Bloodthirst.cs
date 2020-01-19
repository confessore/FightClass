﻿using FightClass.Warrior.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Warrior.TTasks
{
    internal class Bloodthirst : TTask
    {
        readonly ISpellService spellService;

        public Bloodthirst(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 100;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && ObjectManager.Target != null
                && ObjectManager.Me.Rage > 29
                && ObjectManager.Target.HealthPercent > 20
                && spellService.Bloodthirst.KnownSpell
                && spellService.Bloodthirst.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.Bloodthirst.Launch();
        }
    }
}
