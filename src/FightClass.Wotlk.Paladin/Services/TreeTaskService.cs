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

        public TreeTaskService(
            Idle idle,
            Seal seal,
            Blessing blessing,
            Judgement judgement,
            Heal heal,
            ArcaneTorrent arcaneTorrent)
        {
            this.idle = idle;
            this.seal = seal;
            this.blessing = blessing;
            this.judgement = judgement;
            this.heal = heal;
            this.arcaneTorrent = arcaneTorrent;
        }

        TreeTask.TreeTask Idle =>
            new TreeTask.TreeTask(0, new List<TTask>
            {
                idle,
                seal,
                blessing,
                judgement,
                heal,
                arcaneTorrent
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
