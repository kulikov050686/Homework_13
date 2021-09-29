﻿using Microsoft.Extensions.DependencyInjection;
using Homework_13.ViewModels;

namespace Homework_13.Services
{
    /// <summary>
    /// Класс регистрации сервисов и моделей-представления
    /// </summary>
    public static class Registrator
    {
        /// <summary>
        /// Регистрация всех сервисов
        /// </summary>
        /// <param name="services"></param>        
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<BankCustomerRepository>();
            services.AddSingleton<DepartmentRepository>();
            services.AddSingleton<DepositoryAccountRepository>();
            services.AddSingleton<CreditAccountRepository>();

            services.AddSingleton<BankCustomersManager>();
            services.AddSingleton<DepositoryAccountsManager>();
            services.AddSingleton<CreditAccountsManager>();

            services.AddTransient<BankCustomerDialog>();
            services.AddTransient<DepositoryAccountDialog>();
            services.AddTransient<FileIOService>();
            services.AddTransient<FileDialog>();

            return services;
        }

        /// <summary>
        /// Регистрация всех моделей-представления
        /// </summary>
        /// <param name="services"></param>        
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<MainUserControlViewModel>();

            services.AddTransient<MainMenuUserControlViewModel>();

            return services;
        }
    }
}
