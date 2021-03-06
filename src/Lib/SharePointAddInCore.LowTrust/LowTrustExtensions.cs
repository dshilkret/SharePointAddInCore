﻿using Microsoft.Extensions.DependencyInjection;

using SharePointAddInCore.Core.SharePointContext;
using SharePointAddInCore.LowTrust;
using SharePointAddInCore.LowTrust.Authentication;
using SharePointAddInCore.LowTrust.AzureAccessControl;

using System;

namespace SharePointAddInCore
{
    /// <summary>
    /// Extension methods adding the library features to ASP.NET Core Apps.
    /// </summary>
    public static class LowTrustExtensions
    {
        /// <summary>
        /// Adds SharePoint low trust add-in (using OAuth ACS) services.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="configure">The action used to configure the options.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddLowTrustAddIn(this IServiceCollection services, Action<LowTrustSharePointOptions> configure)
        {
            services.AddSharePointCoreServices();

            services.Configure(configure);

            services.AddHttpClient<IAcsClient, AcsClient>();
            services.AddScoped<ISharePointContext, LowTrustSharePointContext>();

            return services;
        }

        /// <summary>
        /// Adds Authentication services with a default <see cref="SharePointAuthentication.SchemeName" /> scheme.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="configureOptions">Optional authentication options configuration.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddSharePointAuthentication(this IServiceCollection services, Action<SharePointAuthenticationOptions> configureOptions = null)
        {
            services
                .AddAuthentication(SharePointAuthentication.SchemeName)
                .AddSharePointAddIn(configureOptions);

            return services;
        }
    }
}
