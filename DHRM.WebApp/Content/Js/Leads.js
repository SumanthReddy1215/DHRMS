$(document).ready(function () {

    var $FromZipCode = $('#FromZipCode');
    var $FromState = $('#f-state');
    var $FromCity = $('#FromCity');

    var $ToZipCode = $('#ToZipCode');
    var $ToState = $('#t-state');
    var $ToCity = $('#ToCity');

    $FromZipCode.focusout(function () {
        if ($FromZipCode.val().length == 5) {
            $.get('/Leads/GetStateByZipCode?zipcode=' + $FromZipCode.val(), function (data, status) {
                $FromState.html('');
                
                //$FromState.append($("<option />").val('').text('Select From State'));
                //don't forget error handling!
                $.each(data, function (key, value) {
                    $FromState.append($("<option />").val(value.StateID).text(value.State));
                });
            });

            $.get('/Leads/GetCityByZipCode?zipcode=' + $FromZipCode.val(), function (data, status) {
                $FromCity.html('');
                $.each(data, function (key, value) {
                    $FromCity.append($("<option />").val(value.CityId).text(value.CityName));
                });
            });
        }
    });

    $ToZipCode.focusout(function () {
        if ($FromZipCode.val().length == 5) {
            $.get('/Leads/GetStateByZipCode?zipcode=' + $ToZipCode.val(), function (data, status) {
                $ToState.html('');

                //$FromState.append($("<option />").val('').text('Select From State'));
                //don't forget error handling!
                $.each(data, function (key, value) {
                    $ToState.append($("<option />").val(value.StateID).text(value.State));
                });
            });

            $.get('/Leads/GetCityByZipCode?zipcode=' + $ToZipCode.val(), function (data, status) {
                $ToCity.html('');
                $.each(data, function (key, value) {
                    $ToCity.append($("<option />").val(value.CityId).text(value.CityName));
                });
            });
        }
    });

});