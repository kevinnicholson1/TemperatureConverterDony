using System;
using TemperatureConverter.Core.Enum;
using TemperatureConverter.Core.Model;

namespace TemperatureConverter.API.DataProviders
{
    public class FahrenheitToCelsiusConverter : ITemperatureConverter
    {
        public Temperature ConvertTemperature(double temperature)
        {
            const double fahrenheitToCelsiusFactor = 1.8;
            const int fahrenheitFreezingPoint = 32;

            return new Temperature
            {
                Scale = TemperatureScale.Celsius,
                TemperatureValue = (temperature - fahrenheitFreezingPoint) / fahrenheitToCelsiusFactor
            };
        }
    }
}
