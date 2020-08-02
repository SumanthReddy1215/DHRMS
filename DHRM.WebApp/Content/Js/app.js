var ParsleyDefaults = {
    errorClass: "has-error",
    successClass: "has-success",
    classHandler: function (ParsleyField) {

        var $this = ParsleyField.$element;
        if ($this.hasClass('undefined'))
            return undefined;
        else
            return $this.closest('.form-group, .input-form, .checkbox, .radio');
    },
    errorsContainer: function (ParsleyField) {
        var $this = ParsleyField.$element;
        return $this.parent();
    },
    errorsWrapper: '<div class="help-block"></div>',
    errorTemplate: '<span></span>'
};

// mask declaration
var maskSettings = {
    minDate : new Date("01/01/1900"),
    maxDate : new Date("12/31/9999"),
    settigs : {
        // date 
        initializeDates: function ($object) {
            $object.find("[date]").attr({
                "data-inputmask-alias": "datetime",
                "data-inputmask-inputformat" :"mm/dd/yyyy",
                "data-parsley-date": ""
            }).each(function () {
                var $this = $(this);
                if ($this.attr("date") == "past")
                {
                    maskSettings.maxDate = new Date();
                }
                else if ($this.attr("date") == "future")
                {
                    maskSettings.minDate = new Date();
                }

                $(this).datetimepicker({
                    format: 'MM/DD/YYYY',
                    useCurrent: false,
                    minDate: maskSettings.minDate,
                    maxDate: maskSettings.maxDate
                });
            }); 
        },
        // phone
        initializePhone: function ($object) {
            $object.find("[data-phone]").attr({
                "data-parsley-phone": "",
                "data-inputmask": "'alias':'999-999-9999'"
            });
        },
    },
    
    initialize : function ($object) {
        this.settigs.initializeDates($object);
        this.settigs.initializePhone($object);
        setTimeout(function () { 
            $("input:text").inputmask(undefined);
        },1000);
    }
};

var parsleyForms;

$(function () {

    // initialize mask
    maskSettings.initialize($(document));

    // Init form validation
    parsleyForms = $('[data-parsley-validate]');

    if (parsleyForms.length) {
        parsleyForms.parsley(ParsleyDefaults);
    }
   
    // button process icon
    $('.btnload').click(function (e) {
        //e.preventDefault();
        var but = $(this).toggleClass('sending').blur();

        //setTimeout(function () {
        //    but.removeClass('sending').blur();
        //}, 2500);

    })
});

var processDialog = {
    show: function () {
        $("#_loading_").show();
    },
    hide: function () {
        $("#_loading_").hide();
    }
};

// Ajax loader
var processTimer;
$(document).ajaxStart(function () {
    processTimer = setTimeout(function () {
        processDialog.show();
    }, 1000);
    
}).ajaxStop(function () {
    clearTimeout(processTimer);
    processDialog.hide();
}).ajaxError(function (e, xhr, opt) {
    
});


// padding zeros
function zeroFill(number, width) {
    width -= number.toString().length;
    if (width > 0) {
        return new Array(width + (/\./.test(number) ? 2 : 1)).join('0') + number;
    }
    return number + ""; // always return a string
}