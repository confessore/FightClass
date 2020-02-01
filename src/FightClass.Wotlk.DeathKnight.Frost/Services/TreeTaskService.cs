using FightClass.Wotlk.DeathKnight.Frost.TTasks;
using FightClass.Wotlk.Shaman.Services.Interfaces;
using FightClass.Wotlk.Shaman.TTasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using TreeTask;

namespace FightClass.Wotlk.Shaman.Services
{
    internal class TreeTaskService : ITreeTaskService
    {
        readonly Idle idle;
        readonly BloodFury bloodFury;
        readonly DeathGrip deathGrip;
        readonly IcyTouch icyTouch;
        readonly PlagueStrike plagueStrike;
        readonly BloodStrike bloodStrike;
        readonly DeathCoil deathCoil;
        readonly HornOfWinter hornOfWinter;
        readonly Obliterate obliterate;
        readonly FrostStrike frostStrike;
        readonly HowlingBlast howlingBlast;
        readonly BloodTap bloodTap;
        readonly EmpoweredRuneWeapon empoweredRuneWeapon;
        readonly UnbreakableArmor unbreakableArmor;
        readonly MindFreeze mindFreeze;

        public TreeTaskService(
            Idle idle,
            BloodFury bloodFury,
            DeathGrip deathGrip,
            IcyTouch icyTouch,
            PlagueStrike plagueStrike,
            BloodStrike bloodStrike,
            DeathCoil deathCoil,
            HornOfWinter hornOfWinter,
            Obliterate obliterate,
            FrostStrike frostStrike,
            HowlingBlast howlingBlast,
            BloodTap bloodTap,
            EmpoweredRuneWeapon empoweredRuneWeapon,
            UnbreakableArmor unbreakableArmor,
            MindFreeze mindFreeze)
        {
            this.idle = idle;
            this.bloodFury = bloodFury;
            this.deathGrip = deathGrip;
            this.icyTouch = icyTouch;
            this.plagueStrike = plagueStrike;
            this.bloodStrike = bloodStrike;
            this.deathCoil = deathCoil;
            this.hornOfWinter = hornOfWinter;
            this.obliterate = obliterate;
            this.frostStrike = frostStrike;
            this.howlingBlast = howlingBlast;
            this.bloodTap = bloodTap;
            this.empoweredRuneWeapon = empoweredRuneWeapon;
            this.unbreakableArmor = unbreakableArmor;
            this.mindFreeze = mindFreeze;
        }

        TreeTask.TreeTask Idle =>
            new TreeTask.TreeTask(0, new List<TTask>
            {
                idle,
                bloodFury,
                deathGrip,
                icyTouch,
                plagueStrike,
                bloodStrike,
                deathCoil,
                hornOfWinter,
                obliterate,
                frostStrike,
                howlingBlast,
                bloodTap,
                empoweredRuneWeapon,
                unbreakableArmor,
                mindFreeze
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
