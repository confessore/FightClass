﻿using FightClass.Vanilla.Warrior.Services.Interfaces;
using robotManager.Helpful;
using System;
using System.Threading.Tasks;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace FightClass.Vanilla.Warrior.Services
{
    internal class RotationService : IRotationService
    {
        readonly ITreeTaskService treeTaskService;

        public RotationService(
            ITreeTaskService treeTaskService)
        {
            this.treeTaskService = treeTaskService;
        }

        public Task RotationAsync()
        {
            while (Main.Running)
            {
                try
                {
                    if (Conditions.InGameAndConnectedAndAliveAndProductStartedNotInPause)
                        if (Fight.InFight && ObjectManager.Me.Target > 0)
                            treeTaskService.TreeTaskHandler.Execute();
                }
                catch (Exception e)
                {
                    Logging.WriteError("[My fightclass] ERROR: " + e);
                }
            }
            return Task.CompletedTask;
        }
    }
}
