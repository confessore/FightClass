using FightClass.Vanilla.Warrior.Services.Interfaces;
using FightClass.Vanilla.Warrior.TreeTasks;
using TreeTaskSharp;

namespace FightClass.Vanilla.Warrior.Services
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
            X execute)
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
                execute);
        }

        public TreeTaskHandler TreeTaskHandler { get; }
    }
}
