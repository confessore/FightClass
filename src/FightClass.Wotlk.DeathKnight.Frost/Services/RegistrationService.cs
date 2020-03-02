using FightClass.Wotlk.DeathKnight.Frost.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace FightClass.Wotlk.DeathKnight.Frost.Services
{
    internal class RegistrationService : IRegistrationService
    {
        readonly IServiceProvider serviceProvider;

        public RegistrationService(
            IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task InitializeAsync()
        {
            await RegisterServicesAsync();
        }

        Task RegisterServicesAsync()
        {
            serviceProvider.GetRequiredService<ISpellService>();
            serviceProvider.GetRequiredService<IRotationService>();
            serviceProvider.GetRequiredService<ITreeTaskService>();
            return Task.CompletedTask;
        }
    }
}
