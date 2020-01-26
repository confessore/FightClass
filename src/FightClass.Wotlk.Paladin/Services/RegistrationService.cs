using FightClass.Wotlk.Paladin.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace FightClass.Wotlk.Paladin.Services
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
