﻿using FightClass.Wotlk.Shaman.Enhancement.Services.Interfaces;
using robotManager.Helpful;
using System;
using System.Threading.Tasks;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Shaman.Enhancement.Services
{
    internal class RotationService : IRotationService
    {
        readonly ITreeTaskService treeTaskService;

        public RotationService(
            ITreeTaskService treeTaskService)
        {
            this.treeTaskService = treeTaskService;
        }

        public async Task RotationAsync()
        {
            while (Main.Running)
            {
                try
                {
                    if (Conditions.InGameAndConnectedAndAliveAndProductStartedNotInPause)
                        if (Fight.InFight && ObjectManager.Me.Target > 0)
                            await treeTaskService.ExecuteTreeTaskAsync();
                }
                catch (Exception e)
                {
                    Logging.WriteError("[My fightclass] ERROR: " + e);
                }
                await Task.Delay(10);
            }
        }
    }
}
