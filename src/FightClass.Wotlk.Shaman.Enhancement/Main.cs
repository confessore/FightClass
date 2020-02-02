using FightClass.Wotlk.Shaman.Enhancement.Services;
using FightClass.Wotlk.Shaman.Enhancement.Services.Interfaces;
using FightClass.Wotlk.Shaman.Enhancement.TTasks;
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
            .AddSingleton<Imbue>()
            .AddSingleton<Shock>()
            .AddSingleton<Heal>()
            .AddSingleton<Shield>()
            .AddSingleton<Totem>()
            .AddSingleton<WindShear>()
            .AddSingleton<Stormstrike>()
            .AddSingleton<LavaLash>()
            .AddSingleton<MaelstromWeapon>()
            .AddSingleton<FeralSpirit>()
            .AddSingleton<ShamanisticRage>()
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
        if (ObjectManager.Me.WowClass == WoWClass.Shaman)
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