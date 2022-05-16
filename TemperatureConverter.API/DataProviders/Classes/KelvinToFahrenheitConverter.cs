using TemperatureConverter.Core.Enum;
using TemperatureConverter.Core.Model;

namespace TemperatureConverter.API.DataProviders
{
    public class KelvinToFahrenheitConverter : ITemperatureConverter
    {
        public Temperature ConvertTemperature(double temperature)
        {
            const double fahrenheitFactor = 1.8;
            const double fahrenHeightToKelvinFreezingPoint = 459.67;

            return new Temperature
            {
                Scale = TemperatureScale.Fahrenheit,
                TemperatureValue = (temperature * fahrenheitFactor) - fahrenHeightToKelvinFreezingPoint
            };
        }
    }
}
