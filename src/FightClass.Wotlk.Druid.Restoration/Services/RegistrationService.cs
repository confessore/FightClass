﻿using FightClass.Wotlk.Druid.Restoration.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace FightClass.Wotlk.Druid.Restoration.Services
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
