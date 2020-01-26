using FightClass.Wotlk.Paladin.Services;
using FightClass.Wotlk.Paladin.Services.Interfaces;
using FightClass.Wotlk.Paladin.TTasks;
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
            .AddSingleton<IRegistrationService, RegistrationService>()
            .AddSingleton<ISpellService, SpellService>()
            .AddSingleton<IRotationService, RotationService>()
            .AddSingleton<ITreeTaskService, TreeTaskService>()
            .AddSingleton<Idle>()
            .AddSingleton<Seal>()
            .AddSingleton<Blessing>()
            .AddSingleton<Judgement>()
            .AddSingleton<Heal>()
            .AddSingleton<ArcaneTorrent>()
            .AddSingleton<Consecration>()
            .AddSingleton<Exorcism>()
            .AddSingleton<CrusaderStrike>()
            .AddSingleton<DivineStorm>()
            .AddSingleton<HammerOfWrath>()
            .AddSingleton<HolyWrath>()
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
        if (ObjectManager.Me.WowClass == WoWClass.Paladin)
        {
            Running = true;
            await serviceProvider.GetRequiredService<IRegistrationService>().InitializeAsync();
            await serviceProvider.GetRequiredService<IRotationService>().RotationAsync();
        }
    }

    public void ShowConfiguration()
    {

    }
}