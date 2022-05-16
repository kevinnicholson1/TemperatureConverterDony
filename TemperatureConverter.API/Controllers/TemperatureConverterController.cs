using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemperatureConverter.Core.Model;
using TemperatureConverter.API.Repository;
using TemperatureConverter.Core.Enum;
using TemperatureConverter.Core.Model;

namespace TemperatureConverter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureConverterController : Controller
    {
        private readonly ITemperatureConverterRepository _temperatureConverterRepository;
        private readonly IHistoryRepository _historyRepository;

        public TemperatureConverterController(ITemperatureConverterRepository temperatureConversionService, IHistoryRepository historyRepository)
        {
            _temperatureConverterRepository = temperatureConversionService;
            _historyRepository = historyRepository;
        }

        [HttpGet]
        [Route("ConvertTemperature")]
        public async Task<Temperature> ConvertTemperature([FromQuery] TemperatureScale convertFromScale, [FromQuery] TemperatureScale convertToScale, [FromQuery] double temperature)
        {
            return await Task.Run(() => _temperatureConverterRepository.ConvertTemperature(convertFromScale,temperature,convertToScale));
        }

        [HttpGet]
        [Route("GetConversionHistory")]
        public async Task<List<ConversionHistoryItem>> GetConversionHistory()
        {
            return await Task.Run(() => _historyRepository.GetAllConvertionHistory());
        }
    }
}
