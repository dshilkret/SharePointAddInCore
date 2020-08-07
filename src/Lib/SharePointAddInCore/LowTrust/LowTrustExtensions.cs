﻿using Microsoft.Extensions.DependencyInjection;

using SharePointAddInCore.Core.Extensions;
using SharePointAddInCore.Core.SharePointContext;
using SharePointAddInCore.LowTrust;

using System;

namespace SharePointAddInCore
{
    public static class LowTrustExtensions
    {
        /// <summary>
        /// Adds SharePoint low trust add-in (using OAuth ACS) services
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="configure">The action used to configure the options.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddLowTrustAddIn(this IServiceCollection services, Action<LowTrustSharePointOptions> configure = null)
        {
            services.AddCoreServices();

            if (configure != null)
            {
                services.Configure(configure);
            }

            services.AddScoped<ISharePointContext, LowTrustSharePointContext>();

            return services;
        }
    }
}
