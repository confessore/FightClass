using FightClass.Vanilla.Warlock.Services.Interfaces;
using FightClass.Vanilla.Warlock.TTasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using TreeTask;

namespace FightClass.Vanilla.Warlock.Services
{
    internal class TreeTaskService : ITreeTaskService
    {
        readonly Idle idle;
        readonly SummonVoidwalker summonVoidwalker;

        public TreeTaskService(
            Idle idle,
            SummonVoidwalker summonVoidwalker)
        {
            this.idle = idle;
            this.summonVoidwalker = summonVoidwalker;
        }

        TreeTask.TreeTask Combat =>
            new TreeTask.TreeTask(0, new List<TTask>
            {
                idle,
                summonVoidwalker
            });

        TreeTask.TreeTask Buff =>
            new TreeTask.TreeTask(1, new List<TTask>
            {
            });

        List<TreeTask.TreeTask> Collection =>
            new List<TreeTask.TreeTask>()
            {
                Combat,
                Buff
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
