using FightClass.Wotlk.Paladin.Services.Interfaces;
using FightClass.Wotlk.Paladin.TTasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using TreeTask;

namespace FightClass.Wotlk.Paladin.Services
{
    internal class TreeTaskService : ITreeTaskService
    {
        readonly Idle idle;
        readonly Seal seal;
        readonly Blessing blessing;
        readonly Judgement judgement;
        readonly Heal heal;
        readonly ArcaneTorrent arcaneTorrent;
        readonly Consecration consecration;
        readonly Exorcism exorcism;
        readonly CrusaderStrike crusaderStrike;
        readonly DivineStorm divineStorm;
        readonly HammerOfWrath hammerOfWrath;
        readonly HolyWrath holyWrath;

        public TreeTaskService(
            Idle idle,
            Seal seal,
            Blessing blessing,
            Judgement judgement,
            Heal heal,
            ArcaneTorrent arcaneTorrent,
            Consecration consecration,
            Exorcism exorcism,
            CrusaderStrike crusaderStrike,
            DivineStorm divineStorm,
            HammerOfWrath hammerOfWrath,
            HolyWrath holyWrath)
        {
            this.idle = idle;
            this.seal = seal;
            this.blessing = blessing;
            this.judgement = judgement;
            this.heal = heal;
            this.arcaneTorrent = arcaneTorrent;
            this.consecration = consecration;
            this.exorcism = exorcism;
            this.crusaderStrike = crusaderStrike;
            this.divineStorm = divineStorm;
            this.hammerOfWrath = hammerOfWrath;
            this.holyWrath = holyWrath;
        }

        TreeTask.TreeTask Idle =>
            new TreeTask.TreeTask(0, new List<TTask>
            {
                idle,
                seal,
                blessing,
                judgement,
                heal,
                arcaneTorrent,
                consecration,
                exorcism,
                crusaderStrike,
                divineStorm,
                hammerOfWrath,
                holyWrath
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
