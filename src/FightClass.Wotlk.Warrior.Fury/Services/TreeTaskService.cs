using FightClass.Wotlk.Warrior.Fury.Services.Interfaces;
using FightClass.Wotlk.Warrior.Fury.TreeTasks;
using TreeTaskSharp;

namespace FightClass.Wotlk.Warrior.Fury.Services
{
    internal class TreeTaskService : ITreeTaskService
    {
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
            X execute,
            VictoryRush victoryRush,
            Slam slam)
        {
            TreeTaskHandler = new TreeTaskHandler(
                idle,
                charge,
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
                execute,
                victoryRush,
                slam);
        }

        public TreeTaskHandler TreeTaskHandler { get; }
    }
}
