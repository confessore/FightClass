using FightClass.Wotlk.Druid.Restoration.Services;
using FightClass.Wotlk.Druid.Restoration.Services.Interfaces;
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
            .BuildServiceProvider();
    }

    public float Range => 29f;
    internal static bool Running { get; set; }

    public void Dispose()
    {
        Running = false;
    }

    public async void Initialize()
    {
        if (ObjectManager.Me.WowClass == WoWClass.Druid)
        {
            Running = true;
            //await serviceProvider.GetRequiredService<IRegistrationService>().InitializeAsync();
            await serviceProvider.GetRequiredService<IRotationService>().RotationAsync();
        }
    }

    public void ShowConfiguration()
    {

    }
}