using TemperatureConverter.Core.Enum;
using TemperatureConverter.Core.Model;

namespace TemperatureConverter.API.DataProviders
{
    public class FahrenheitToKelvinConverter : ITemperatureConverter
    {
        public Temperature ConvertTemperature(double temperature)
        {
            const double kelvinFactor = 0.5555555555555556;
            const double fahrenHeightToKelvinFreezingPoint = 459.67;

            return new Temperature
            {
                Scale = TemperatureScale.Kelvin,
                TemperatureValue = (temperature + fahrenHeightToKelvinFreezingPoint) * kelvinFactor
            };
        }
    }
}
