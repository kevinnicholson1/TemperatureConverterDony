# Temperature Converter

Temperatures can be converted between celsius, Fahrenheit, and Kelvin.

## Description

This converter can be used to convert the following temperature conversions:

1. Celsius to Kelvin conversion

2. Celsius to Fahrenheit conversion

3. Kelvin to Celsius conversion

4. Kelvin to Fahrenheit conversion

5. Fahrenheit to Celsius conversion

6. Fahrenheit to Kelvin conversion

## Getting Started

### Dependencies

  1. Asp.net Core 3.1

  2. Asp.net Core Rest API

  3. jQuery

### Product Structure

Two solutions are included in this project.

  1. TemperatureConverter.API

  2. TemperatureConverter.Web

Both these projects share a core project, Printerland.Core.

#### API project Application Configuration

The default url, https://localhost:44395" is configured inside the launchsettings.json

The WebProject url ("https://localhost:44329") is added in the AppSettings file as AllowedDomains. This value is used to setup allowed domains inside the API project statup class.

#### Web project Application Configuration

Defaut url https://localhost:44329 is configured inside the launchsettings.json file.

The API url is set in the appSettings.json file.

## Steps to build the project

  1. Open TemperatureConverter.API solution

  2. Build this solution

  3. run TemperatureConverter.API project

  4. Open TemperatureConverter.Web solution

  5. Build this solution

  6. run TemperatureConverter.Web project


