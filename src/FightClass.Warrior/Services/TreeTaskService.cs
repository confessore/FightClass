﻿using FightClass.Warrior.Services.Interfaces;
using FightClass.Warrior.TTasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using TreeTask;

namespace FightClass.Warrior.Services
{
    internal class TreeTaskService : ITreeTaskService
    {
        readonly Idle idle;
        readonly Charge charge;
        readonly Pummel pummel;
        readonly BerserkerStance berserkerStance;
        readonly Bloodrage bloodrage;
        readonly BattleShout battleShout;
        readonly Bloodthirst bloodthirst;
        readonly MortalStrike mortalStrike;
        readonly ShieldSlam shieldSlam;
        readonly Whirlwind whirlwind;
        readonly HeroicStrike heroicStrike;
        readonly SunderArmor sunderArmor;
        readonly X execute;

        public TreeTaskService(
            Idle idle,
            Charge charge,
            Pummel pummel,
            BerserkerStance berserkerStance,
            Bloodrage bloodrage,
            BattleShout battleShout,
            Bloodthirst bloodthirst,
            MortalStrike mortalStrike,
            ShieldSlam shieldSlam,
            Whirlwind whirlwind,
            HeroicStrike heroicStrike,
            SunderArmor sunderArmor,
            X execute)
        {
            this.idle = idle;
            this.charge = charge;
            this.pummel = pummel;
            this.berserkerStance = berserkerStance;
            this.bloodrage = bloodrage;
            this.battleShout = battleShout;
            this.bloodthirst = bloodthirst;
            this.mortalStrike = mortalStrike;
            this.shieldSlam = shieldSlam;
            this.whirlwind = whirlwind;
            this.heroicStrike = heroicStrike;
            this.sunderArmor = sunderArmor;
            this.execute = execute;
        }

        TreeTask.TreeTask Idle =>
            new TreeTask.TreeTask(0, new List<TTask>
            {
                idle,
                charge,
                //new Intercept(),
                pummel,
                berserkerStance,
                bloodrage,
                battleShout,
                bloodthirst,
                mortalStrike,
                shieldSlam,
                whirlwind,
                heroicStrike,
                sunderArmor,
                execute
            });

        TreeTask.TreeTask Dead =>
            new TreeTask.TreeTask(1, new List<TTask> { });

        List<TreeTask.TreeTask> Collection =>
            new List<TreeTask.TreeTask>()
            {
                Idle,
                Dead
            };

        TreeTask.TreeTask TreeTask =>
            new TreeTask.TreeTask(100, Collection);

        public Task ExecuteTreeTaskAsync()
        {
            if (TreeTask.Activate())
                TreeTask.Execute();
            return Task.CompletedTask;
        }
    }
}