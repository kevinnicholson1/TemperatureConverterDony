using TemperatureConverter.Core.Model;
namespace TemperatureConverter.API.DataProviders
{
    public interface ITemperatureConverter
    {
        Temperature ConvertTemperature(double temperature);
    }
}
