using TemperatureConverter.Core.Model;
using TemperatureConverter.Core.Enum;

namespace TemperatureConverter.API.DataProviders
{
    public class CelsiusToFahrenheitConverter : ITemperatureConverter
    {
        public Temperature ConvertTemperature(double temperature)
        {
            const double celsiusToFahrenheitFactor = 1.8;
            const int fahrenheitFreezingPoint = 32;

            return new Temperature
            {
                Scale = TemperatureScale.Fahrenheit,
                TemperatureValue = (temperature * celsiusToFahrenheitFactor) + fahrenheitFreezingPoint
            };
        }
    }
}
