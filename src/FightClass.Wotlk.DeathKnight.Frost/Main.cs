using FightClass.Wotlk.DeathKnight.Frost.TTasks;
using FightClass.Wotlk.DeathKnight.Frost.Services;
using FightClass.Wotlk.DeathKnight.Frost.Services.Interfaces;
using FightClass.Wotlk.DeathKnight.Frost.TTasks;
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
            .AddSingleton<BloodFury>()
            .AddSingleton<DeathGrip>()
            .AddSingleton<IcyTouch>()
            .AddSingleton<PlagueStrike>()
            .AddSingleton<BloodStrike>()
            .AddSingleton<DeathCoil>()
            .AddSingleton<Obliterate>()
            .AddSingleton<FrostStrike>()
            .AddSingleton<HornOfWinter>()
            .AddSingleton<HowlingBlast>()
            .AddSingleton<BloodTap>()
            .AddSingleton<EmpoweredRuneWeapon>()
            .AddSingleton<UnbreakableArmor>()
            .AddSingleton<MindFreeze>()
            .BuildServiceProvider();
    }

    public float Range => 5f;
    internal static bool Running { get; set; }

    public void Dispose()
    {
        Running = false;
    }

    public async void Initialize()
    {
        if (ObjectManager.Me.WowClass == WoWClass.DeathKnight)
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