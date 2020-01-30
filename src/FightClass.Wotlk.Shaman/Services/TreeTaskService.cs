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
        readonly Imbue imbue;
        readonly Shock shock;
        readonly Heal heal;
        readonly Shield shield;
        readonly Totem totem;
        readonly WindShear windShear;
        readonly Stormstrike stormstrike;
        readonly LavaLash lavaLash;
        readonly MaelstromWeapon maelstromWeapon;
        readonly FeralSpirit feralSpirit;
        readonly ShamanisticRage shamanisticRage;

        public TreeTaskService(
            Idle idle,
            Imbue imbue,
            Shock shock,
            Heal heal,
            Shield shield,
            Totem totem,
            WindShear windShear,
            Stormstrike stormstrike,
            LavaLash lavaLash,
            MaelstromWeapon maelstromWeapon,
            FeralSpirit feralSpirit,
            ShamanisticRage shamanisticRage)
        {
            this.idle = idle;
            this.imbue = imbue;
            this.shock = shock;
            this.heal = heal;
            this.shield = shield;
            this.totem = totem;
            this.windShear = windShear;
            this.stormstrike = stormstrike;
            this.lavaLash = lavaLash;
            this.maelstromWeapon = maelstromWeapon;
            this.feralSpirit = feralSpirit;
            this.shamanisticRage = shamanisticRage;
        }

        TreeTask.TreeTask Idle =>
            new TreeTask.TreeTask(0, new List<TTask>
            {
                idle,
                imbue,
                shock,
                heal,
                shield,
                totem,
                windShear,
                stormstrike,
                lavaLash,
                maelstromWeapon,
                feralSpirit,
                shamanisticRage
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
