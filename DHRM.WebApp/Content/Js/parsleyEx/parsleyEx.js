/* Phone Validation */
window.Parsley.addValidator('phone', {
    validateString: function (value, maxData, parslyObj) {
        var isValid = Inputmask.isValid(value, { alias: "999-999-9999" });
        if (!isValid && parslyObj.$element.attr("data-phone") !== "")
        {
            return $.Deferred().reject(parslyObj.$element.attr("data-phone"));
        }
        return isValid;
    },
    messages: {
        en: 'Invalid phone number.',
        fr: ""
    }
});

/* Phone Validation */
window.Parsley.addValidator('date', {
    validateString: function (value, maxData, parslyObj) {
        var isValid = Inputmask.isValid(value, { alias: "mm/dd/yyyy" });
        if (!isValid && parslyObj.$element.attr("date") !== "") {
            return $.Deferred().reject(parslyObj.$element.attr("date"));
        }
        return isValid;
    },
    messages: {
        en: 'Invalid date.',
        fr: ""
    }
});

/* Email Validation */
window.Parsley.addValidator('email', {
    validateString: function (value) {
        var isValid = Inputmask.isValid(value, { alias: "email" });
        return isValid;
    },
    messages: {
        en: 'Invalid email address.',
        fr: ""
    }
});

window.ParsleyValidator
        .addValidator('fileextension', function (value, requirement) {
            var fileExtension = value.split('.').pop();

            return fileExtension === requirement;
        }, 32)
        .addMessage('en', 'fileextension', 'The extension doesn\'t match the required');