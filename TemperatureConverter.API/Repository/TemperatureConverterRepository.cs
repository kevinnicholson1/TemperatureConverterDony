using System;
using TemperatureConverter.API.DataProviders;
using TemperatureConverter.Core.Enum;
using TemperatureConverter.Core.Model;

namespace TemperatureConverter.API.Repository
{
    public class TemperatureConverterRepository : ITemperatureConverterRepository
    {
        private readonly Func<TemperatureScale, TemperatureScale, ITemperatureConverter> _temperatureConverter;
        private readonly IConversionHistory _temperatureHistory;

        public TemperatureConverterRepository(Func<TemperatureScale, TemperatureScale, ITemperatureConverter> temperatureConverter, IConversionHistory temperatureHistory)
        {
            _temperatureConverter = temperatureConverter;
            _temperatureHistory = temperatureHistory;
        }

        public Temperature ConvertTemperature(TemperatureScale convertFromScale, double temperature, TemperatureScale convertToScale)
        {
            Temperature output;
            if (convertFromScale == convertToScale)
            {
                output= new Temperature { Scale = convertToScale, TemperatureValue = temperature };
            }
            else
            {
                output= _temperatureConverter(convertFromScale, convertToScale).ConvertTemperature(temperature);
            }

            CreateHistoryRecord(convertFromScale, temperature, convertToScale);

            return output;
        }

        #region PrivateMethodes
        private void CreateHistoryRecord(TemperatureScale convertFromScale, double temperature, TemperatureScale convertToScale)
        {
            _temperatureHistory.Create(new ConversionHistoryItem
            {
                ConvertFromScale = convertFromScale,
                ConvertToScale = convertToScale,
                Temperature = temperature
            });
        }
        #endregion
    }
}
