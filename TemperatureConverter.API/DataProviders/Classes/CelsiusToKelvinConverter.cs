﻿using TemperatureConverter.Core.Enum;
using TemperatureConverter.Core.Model;

namespace TemperatureConverter.API.DataProviders
{
    public class CelsiusToKelvinConverter : ITemperatureConverter
    {
        public Temperature ConvertTemperature(double temperature)
        {
            const double kelvinFreezingPoint = 273.15;

            return new Temperature
            {
                Scale = TemperatureScale.Kelvin,
                TemperatureValue = temperature + kelvinFreezingPoint
            };
        }
    }
}
