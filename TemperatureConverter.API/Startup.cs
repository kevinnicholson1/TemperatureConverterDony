using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TemperatureConverter.API.DataProviders;
using TemperatureConverter.Core.Enum;
using TemperatureConverter.API.Repository;

namespace TemperatureConverter.API
{
    public class Startup
    {
        private const string CORE_POLICY_NAME = "ApiCorsPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            const string ALLOWED_DOMAINS_KEY = "AllowedDomains";
            
            var allowedOrigins = Configuration.GetSection(ALLOWED_DOMAINS_KEY).Get<string[]>();
            services.AddCors(options => options.AddPolicy(CORE_POLICY_NAME, builder =>
            {
                builder.WithOrigins(allowedOrigins).AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddControllers();
            services.AddTransient<CelsiusToFahrenheitConverter>();
            services.AddTransient<CelsiusToKelvinConverter>();
            services.AddTransient<FahrenheitToCelsiusConverter>();
            services.AddTransient<FahrenheitToKelvinConverter>();
            services.AddTransient<KelvinToFahrenheitConverter>();
            services.AddTransient<KelvinToCelsiusConverter>();
            services.AddTransient<IHistoryRepository, HistoryRepository>();
            services.AddSingleton<IConversionHistory, ConversionHistory>();

            services.AddTransient<Func<TemperatureScale, TemperatureScale, ITemperatureConverter>>(serviceProvider => (convertFromScale, convertToScale) =>
            {
                if (convertFromScale == TemperatureScale.Celsius)
                {
                    if (convertToScale == TemperatureScale.Fahrenheit)
                    {
                        return serviceProvider.GetService<CelsiusToFahrenheitConverter>();
                    }
                    else if (convertToScale == TemperatureScale.Kelvin)
                    {
                        return serviceProvider.GetService<CelsiusToKelvinConverter>();
                    }
                }
                else if (convertFromScale == TemperatureScale.Fahrenheit)
                {
                    if (convertToScale == TemperatureScale.Celsius)
                    {
                        return serviceProvider.GetService<FahrenheitToCelsiusConverter>();
                    }
                    else if (convertToScale == TemperatureScale.Kelvin)
                    {
                        return serviceProvider.GetService<FahrenheitToKelvinConverter>();
                    }
                }
                else if (convertFromScale == TemperatureScale.Kelvin)
                {
                    if (convertToScale == TemperatureScale.Celsius)
                    {
                        return serviceProvider.GetService<KelvinToCelsiusConverter>();
                    }
                    else if (convertToScale == TemperatureScale.Fahrenheit)
                    {
                        return serviceProvider.GetService<KelvinToFahrenheitConverter>();
                    }
                }

                throw new NotImplementedException();
            });

            services.AddTransient<ITemperatureConverterRepository, TemperatureConverterRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(CORE_POLICY_NAME);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
