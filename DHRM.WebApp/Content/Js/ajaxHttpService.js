(function ($) {
    // ajax post
    $.ajaxPost = function (url, data, success, error) {
        $.ajax({
            url: url,
            type: 'POST',
            data: data,
            cache: false,
            success: function (response, status, xhr) {
                if (success) success(response, status, xhr);
            },
            error: function (xhr, status, errorText) {
                console.error(errorText, xhr.responseJSON);
                if (error)
                    error(xhr, status, errorText);
                else
                {
                    alert(errorText);
                }
            }
        });
    };

    // ajax get
    $.ajaxGet = function (url, data, success, error) {
        $.ajax({
            url: url,
            type: 'GET',
            data: data,
            cache: false,

            success: function (response, status, xhr) {
                if (success) success(response, status, xhr);
            },
            error: function (xhr, status, errorText) {
                console.error(errorText, xhr.responseJSON);
                if (error)
                    error(xhr, status, errorText);
                else {
                    alert(errorText);
                }
            }
        });
    };

}(jQuery));

(function ($) {

    $.fn.openPopup = function () {
        // Open popup code.
    };

    $.fn.closePopup = function () {
        // Close popup code.
    };

}(jQuery));