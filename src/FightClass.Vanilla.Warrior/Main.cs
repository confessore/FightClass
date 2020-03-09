using FightClass.Vanilla.Warrior.Services;
using FightClass.Vanilla.Warrior.Services.Interfaces;
using FightClass.Vanilla.Warrior.TreeTasks;
using Microsoft.Extensions.DependencyInjection;
using System;
using wManager.Wow.Enums;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

public class Main : ICustomClass
{
    readonly IServiceProvider serviceProvider;

    public Main()
    {
        serviceProvider = ConfigureServices();
    }

    IServiceProvider ConfigureServices()
    {
        return new ServiceCollection()
            .AddSingleton<ISpellService, SpellService>()
            .AddSingleton<IRotationService, RotationService>()
            .AddSingleton<ITreeTaskService, TreeTaskService>()
            .AddSingleton<Idle>()
            .AddSingleton<Charge>()
            .AddSingleton<Bloodrage>()
            .AddSingleton<BattleShout>()
            .AddSingleton<BerserkerStance>()
            .AddSingleton<Pummel>()
            .AddSingleton<Bloodthirst>()
            .AddSingleton<MortalStrike>()
            .AddSingleton<ShieldSlam>()
            .AddSingleton<Whirlwind>()
            .AddSingleton<HeroicStrike>()
            .AddSingleton<SunderArmor>()
            .AddSingleton<X>()
            .BuildServiceProvider();
    }

    public float Range => 4f;
    internal static bool Running { get; set; }

    public void Dispose()
    {
        Running = false;
    }

    public async void Initialize()
    {
        if (ObjectManager.Me.WowClass == WoWClass.Warrior)
        {
            Running = true;
            await serviceProvider.GetRequiredService<IRotationService>().RotationAsync();
        }
    }

    public void ShowConfiguration()
    {

    }
}