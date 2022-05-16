using System.Collections.Generic;
using TemperatureConverter.Core.Model;

namespace TemperatureConverter.API.Repository
{
    public interface IHistoryRepository
    {
        List<ConversionHistoryItem> GetAllConvertionHistory();
    }
}
