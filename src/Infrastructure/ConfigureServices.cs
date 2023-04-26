﻿using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Infrastructure.Files;
using OnlineApplicationSystem.Infrastructure.Identity;
using OnlineApplicationSystem.Infrastructure.Persistence;
using OnlineApplicationSystem.Infrastructure.Persistence.Interceptors;
using OnlineApplicationSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineApplicationSystem.Infrastructure.Persistence.Repositories;
using OnlineApplicationSystem.Infrastructure.Mails;
using OnlineApplicationSystem.Infrastructure.SMS;
using Coravel;
using OnlineApplicationSystem.Infrastructure.Common;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("OnlineApplicationSystemDb"));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        services
            .AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddIdentityServer()
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();
        services.AddTransient<IApplicantRepository, ApplicantRepository>();
        services.AddTransient<IEmailSender, EmailService>();
        services.AddTransient<ISmsSender, SmsService>();
        services.AddTransient<IDocumentUploadService, DocumentUploadService>();
        services.AddTransient<IPhotoUploadService, PhotoUploadService>();
        services.AddAuthentication()
            .AddIdentityServerJwt();

        services.AddAuthorization(options =>
            options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));
        //services.AddScheduler();

        services.Configure<MailSettings>(configuration.GetSection(nameof(MailSettings)));

        return services;


    }
}
