using FightClass.Vanilla.Warrior.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace FightClass.Vanilla.Warrior.Services
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
            return Task.CompletedTask;
        }
    }
}
