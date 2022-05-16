using TemperatureConverter.Core.Enum;
using TemperatureConverter.Core.Model;

namespace TemperatureConverter.API.Repository
{
    public interface ITemperatureConverterRepository
    {
        Temperature ConvertTemperature(TemperatureScale inputScale,double temperature,TemperatureScale outputScale);
    }
}
