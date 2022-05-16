$('#btnConvert').on("click", function () {
    var fromScale = $('#ConvertFromScale option:selected').text();
    var toScale = $('#ConvertToScale option:selected').text();
    var convertTemperature = $('#ConvertFromTemperature').val();
    $.ajax({
        url: apiUrl + "TemperatureConverter/ConvertTemperature?convertFromScale=" + fromScale + " &convertToScale=" + toScale + '&temperature=' + convertTemperature,
        contentType: "application/json",
        dataType: 'json',
        success: function (result) {
            $('#ConvertToTemperature').val(result.temperatureValue.toFixed(2));
        },
        error: function (error) {
            console.log(error);
        }
    });
});