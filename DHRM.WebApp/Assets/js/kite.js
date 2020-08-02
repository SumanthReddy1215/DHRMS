// =======
// Kite.js
// =======

// Contains theme specific JS code (plugins initialization, etc.)


$(function() {

    /**
     * CountTo
     */

    var countTo = $(".count-to");

    if ( countTo.length ) {

        countTo.countTo({
            refreshInterval: 20
        });

    }


    /*
     * Parsley validation
     */

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
        errorsContainer: function(ParsleyField) {
            var $this = ParsleyField.$element;
            return $this.parent();
        },
        errorsWrapper: '<div class="help-block"></div>',
        errorTemplate: '<span></span>'
    };

    // Init form validation

    var parsleyForms = $('[data-parsley-validate]');

    if ( parsleyForms.length ) {
        parsleyForms.parsley(ParsleyDefaults);
    }


    /**
     * Bootstrap Datetimepicker
     */

    var datetimepickerElements = $('[data-toggle="datetimepicker"]');

    if ( datetimepickerElements.length ) {

        $('#datetimepicker1, #datetimepicker3').datetimepicker({
            icons: {
                time: 'fa fa-clock-o',
                date: 'fa fa-calendar',
                up: ' fa fa-angle-up',
                down: 'fa fa-angle-down',
                previous: 'fa fa-angle-left',
                next: 'fa fa-angle-right',
                today: 'fa fa-crosshairs',
                clear: 'fa fa-trash',
                close: 'fa fa-times'
            }
        });
        $('#datetimepicker2').datetimepicker({
            icons: {
                time: 'fa fa-clock-o',
                date: 'fa fa-calendar',
                up: ' fa fa-angle-up',
                down: 'fa fa-angle-down',
                previous: 'fa fa-angle-left',
                next: 'fa fa-angle-right',
                today: 'fa fa-crosshairs',
                clear: 'fa fa-trash',
                close: 'fa fa-times'
            },
            format: 'LT'
        });
        $('#datetimepicker4').datetimepicker({
            icons: {
                time: 'fa fa-clock-o',
                date: 'fa fa-calendar',
                up: ' fa fa-angle-up',
                down: 'fa fa-angle-down',
                previous: 'fa fa-angle-left',
                next: 'fa fa-angle-right',
                today: 'fa fa-crosshairs',
                clear: 'fa fa-trash',
                close: 'fa fa-times'
            },
            defaultDate: "11/1/2013",
            disabledDates: [
                moment("12/25/2013"),
                new Date(2013, 11 - 1, 21),
                "11/22/2013 00:53"
            ]
        });
        $('#datetimepicker5').datetimepicker({
            icons: {
                time: 'fa fa-clock-o',
                date: 'fa fa-calendar',
                up: ' fa fa-angle-up',
                down: 'fa fa-angle-down',
                previous: 'fa fa-angle-left',
                next: 'fa fa-angle-right',
                today: 'fa fa-crosshairs',
                clear: 'fa fa-trash',
                close: 'fa fa-times'
            }
        });
        $('#datetimepicker6').datetimepicker({
            icons: {
                time: 'fa fa-clock-o',
                date: 'fa fa-calendar',
                up: ' fa fa-angle-up',
                down: 'fa fa-angle-down',
                previous: 'fa fa-angle-left',
                next: 'fa fa-angle-right',
                today: 'fa fa-crosshairs',
                clear: 'fa fa-trash',
                close: 'fa fa-times'
            },
            useCurrent: false //Important! See issue #1075
        });
        $("#datetimepicker5").on("dp.change", function (e) {
            $('#datetimepicker6').data("DateTimePicker").minDate(e.date);
        });
        $("#datetimepicker6").on("dp.change", function (e) {
            $('#datetimepicker5').data("DateTimePicker").maxDate(e.date);
        });
        $('#datetimepicker7').datetimepicker({
            icons: {
                time: 'fa fa-clock-o',
                date: 'fa fa-calendar',
                up: ' fa fa-angle-up',
                down: 'fa fa-angle-down',
                previous: 'fa fa-angle-left',
                next: 'fa fa-angle-right',
                today: 'fa fa-crosshairs',
                clear: 'fa fa-trash',
                close: 'fa fa-times'
            },
            viewMode: 'years'
        });
        $('#datetimepicker8').datetimepicker({
            icons: {
                time: 'fa fa-clock-o',
                date: 'fa fa-calendar',
                up: ' fa fa-angle-up',
                down: 'fa fa-angle-down',
                previous: 'fa fa-angle-left',
                next: 'fa fa-angle-right',
                today: 'fa fa-crosshairs',
                clear: 'fa fa-trash',
                close: 'fa fa-times'
            },
            viewMode: 'years',
            format: 'MM/YYY'
        });
        $('#datetimepicker9').datetimepicker({
            icons: {
                time: 'fa fa-clock-o',
                date: 'fa fa-calendar',
                up: ' fa fa-angle-up',
                down: 'fa fa-angle-down',
                previous: 'fa fa-angle-left',
                next: 'fa fa-angle-right',
                today: 'fa fa-crosshairs',
                clear: 'fa fa-trash',
                close: 'fa fa-times'
            },
            daysOfWeekDisabled: [0, 6]
        });
        $('#datetimepicker10').datetimepicker({
            icons: {
                time: 'fa fa-clock-o',
                date: 'fa fa-calendar',
                up: ' fa fa-angle-up',
                down: 'fa fa-angle-down',
                previous: 'fa fa-angle-left',
                next: 'fa fa-angle-right',
                today: 'fa fa-crosshairs',
                clear: 'fa fa-trash',
                close: 'fa fa-times'
            },
            inline: true,
            sideBySide: true
        });
    }


    /**
     * Bootstrap Slider
     */

    var sliders = $('[data-slider-value]');

    if ( sliders.length ) {

        $('#ex1').slider({
            formatter: function(value) {
                return 'I am ' + value + ' years old';
            }
        });
        $("#ex2").slider({});
        $("#ex4").slider({
            reversed : true
        });
        $("#ex7").slider();
        $("#ex7-enabled").click(function() {
            if(this.checked) {
                // With JQuery
                $("#ex7").slider("enable");

                // Without JQuery
                slider.enable();
            }
            else {
                // With JQuery
                $("#ex7").slider("disable");

                // Without JQuery
                slider.disable();
            }
        });
        $("#ex8").slider({
            tooltip: 'always'
        });
        $("#ex13").slider({
            ticks: [0, 100, 200, 300, 400],
            ticks_labels: ['$0', '$10', '$20', '$30', '$40'],
            ticks_snap_bounds: 30
        });

    }


    /**
     * Bootstrap Colorpicker
     */

    var colorpickers = $('[data-toggle="colorpicker"]');

    if ( colorpickers.length ) {

        $('#cp1').colorpicker();
        $('#cp2').colorpicker();
        $('#cp3').colorpicker({
            color: '#AA3399',
            format: 'rgb'
        });
        $('#cp6').colorpicker({
            color: "#88cc33",
            horizontal: true
        });
        $('#cp7').colorpicker({
            color: '#ffaa00',
            container: true,
            inline: true
        });
        $('#cp9').colorpicker({
            customClass: 'colorpicker-2x',
            sliders: {
                saturation: {
                    maxLeft: 200,
                    maxTop: 200
                },
                hue: {
                    maxTop: 200
                },
                alpha: {
                    maxTop: 200
                }
            }
        });
    }


    /**
     * Datatables
     */

    var datatables = $('[data-toggle="datatable"]');

    if ( datatables.length ) {

        /*** Example 1 ***/

        $('#datatable_1').DataTable({
            responsive: true
        });

        /*** Example 2 ***/

        $('#ex2').one('shown.bs.collapse', function() {

            var datatableTwo = datatableTwo = $('#datatable_2').DataTable({
                responsive: true
            });

            // Apply the search
            datatableTwo.columns().every( function () {
                var that = this;
         
                $( 'input', this.footer() ).on( 'keyup change', function () {
                    if ( that.search() !== this.value ) {
                        that
                            .search( this.value )
                            .draw();
                    }
                } );
            } );
        });

        /*** Example 3 ***/

        $('#ex3').one('shown.bs.collapse', function() {

            var datatableThree = $('#datatable_3').DataTable( {
                responsive: true,
                buttons: [
                    'copy', 'excel', 'pdf'
                ]
            } );
              
            datatableThree.buttons().container()
                .prependTo( $('.col-sm-6:eq(0)', datatableThree.table().container() ) );

        });

        /*** Example 4 ***/

        $('#ex4').one('shown.bs.collapse', function() {

            $('#datatable_4').DataTable({
                resposive: true,
                colReorder: true
            });

        });

        /*** Example 5 ***/

        $('#ex5').one('shown.bs.collapse', function() {

            $('#datatable_5').DataTable({
                rowReorder: true,
                responsive: true
            });

        });

        /*** Example 6 ***/

        $('#ex6').one('shown.bs.collapse', function() {
            $('#datatable_6').DataTable({
                responsive: true,
                scrollY: 250,
                deferRender: true
            });
        });

        /*** Example 7 ***/

        $('#ex7').one('shown.bs.collapse', function() {

            $('#datatable_7').DataTable({
                responsive: true,
                select: true
            });

        });

        /*** Example: 8 ***/

        $('#datatable_8').DataTable({
            responsive: false
        });

    }


    /**
     * Chart.js
     */

    // Charts: Visitors
    if ($(".chart_visitors").length) {

        Chart.defaults.global.responsive = true;
        Chart.defaults.global.legend.display = false;
        
        var ctx = $(".chart_visitors").get(0).getContext("2d");
        var chartVisitors = new Chart(ctx, {
            type: "line",
            data: {
                labels: ["01/03", "02/03", "03/03", "04/03", "05/03", "06/03", "07/03"],
                datasets: [
                    {
                        label: "Visitors",
                        fill: true,
                        borderWidth: 2,
                        backgroundColor: 'rgba(255, 205, 210, .25)',
                        borderColor: '#EF5350',
                        pointBorderColor: "#fff",
                        pointBackgroundColor: '#EF5350',
                        pointBorderWidth: 2,
                        pointHoverBackgroundColor: '#EF5350',
                        pointHoverBorderColor: "#fff",
                        pointHoverBorderWidth: 2,
                        pointRadius: 3,
                        data: [2800, 4800, 4500, 1900, 8600, 2700, 9000]
                    }
                ]
            }
        });
    }

    // Charts: Revenue
    if ($(".chart_revenue").length) {

        Chart.defaults.global.responsive = true;
        Chart.defaults.global.legend.display = false;
        
        var ctx = $(".chart_revenue").get(0).getContext("2d");
        var chartRevenue = new Chart(ctx, {
            type: "line",
            data: {
                labels: ["Oct", "Nov", "Dec", "Jan", "Feb", "Mar"],
                datasets: [
                    {
                        label: "Revenue",
                        fill: true,
                        borderWidth: 2,
                        backgroundColor: 'rgba(187, 222, 251, .25)',
                        borderColor: '#42A5F5',
                        pointBorderColor: "#fff",
                        pointBackgroundColor: '#42A5F5',
                        pointBorderWidth: 2,
                        pointHoverBackgroundColor: '#42A5F5',
                        pointHoverBorderColor: "#fff",
                        pointHoverBorderWidth: 2,
                        pointRadius: 3,
                        data: [18, 14, 26, 22, 28, 40],
                    }
                ]
            }
        });
    }

    // Chart: Daily sales

    var chartDailySales = $('.chart_daily-sales');

    if ( chartDailySales.length ) {
        Chart.defaults.global.responsive = true;
        Chart.defaults.global.legend.display = false;
        
        var ctx = chartDailySales.get(0).getContext("2d");
        var chartDailySalesChart = new Chart(ctx, {
            type: "line",
            data: {
                labels: ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"],
                datasets: [
                    {
                        label: "Credit sales",
                        fill: true,
                        borderWidth: 2,
                        backgroundColor: 'transparent',
                        borderColor: '#EF5350',
                        pointBorderColor: "#fff",
                        pointBackgroundColor: '#EF5350',
                        pointBorderWidth: 2,
                        pointHoverBackgroundColor: '#EF5350',
                        pointHoverBorderColor: "#fff",
                        pointHoverBorderWidth: 2,
                        pointRadius: 3,
                        data: [1000, 1500, 1200, 2500, 2000, 800, 600]
                    },
                    {
                        label: "Channel sales",
                        fill: true,
                        borderWidth: 2,
                        backgroundColor: 'transparent',
                        borderColor: '#FFA726',
                        pointBorderColor: "#fff",
                        pointBackgroundColor: '#FFA726',
                        pointBorderWidth: 2,
                        pointHoverBackgroundColor: '#FFA726',
                        pointHoverBorderColor: "#fff",
                        pointHoverBorderWidth: 2,
                        pointRadius: 3,
                        data: [1800, 1600, 2100, 2800, 3700, 2000, 800]
                    },
                    {
                        label: "Channel sales",
                        fill: true,
                        borderWidth: 2,
                        backgroundColor: 'transparent',
                        borderColor: '#66BB6A',
                        pointBorderColor: "#fff",
                        pointBackgroundColor: '#66BB6A',
                        pointBorderWidth: 2,
                        pointHoverBackgroundColor: '#66BB6A',
                        pointHoverBorderColor: "#fff",
                        pointHoverBorderWidth: 2,
                        pointRadius: 3,
                        data: [2200, 3000, 3500, 3300, 4200, 2500, 2000]
                    }
                ]   
            }
        });
    }

    // Chart: Total

    var chartTotalSales = $('.chart_total-sales');

    if ( chartTotalSales.length ) {
        Chart.defaults.global.responsive = true;
        Chart.defaults.global.legend.display = false;
        
        var ctx = chartTotalSales.get(0).getContext("2d");
        var chartTotalSalesChart = new Chart(ctx, {
            type: "bar",
            data: {
                labels: ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"],
                datasets: [
                    {
                        label: "Total values",
                        fill: true,
                        borderWidth: 1,
                        backgroundColor: '#81D4FA',
                        borderColor: '#29B6F6',
                        pointBorderColor: "#29B6F6",
                        pointBackgroundColor: '#29B6F6',
                        pointBorderWidth: 2,
                        pointHoverBackgroundColor: '#29B6F6',
                        pointHoverBorderColor: "#29B6F6",
                        pointHoverBorderWidth: 2,
                        pointRadius: 3,
                        data: [4000, 6000, 4800, 10000, 8000, 3200, 2400]
                    }
                ]   
            }
        });
    }

    // Chart examples: Line chart
    if ($(".chart_linechart").length) {

        Chart.defaults.global.responsive = true;
        Chart.defaults.global.legend.display = false;
        
        var ctx = $(".chart_linechart").get(0).getContext("2d");
        var chartLineChart = new Chart(ctx, {
            type: "line",
            data: {
            labels: ["January", "February", "March", "April", "May", "June", "July"],
                datasets: [
                    {
                        label: "My First dataset",
                        fill: true,
                        borderWidth: 2,
                        backgroundColor: 'transparent',
                        borderColor: '#EF5350',
                        pointBorderColor: "#fff",
                        pointBackgroundColor: '#EF5350',
                        pointBorderWidth: 2,
                        pointHoverBackgroundColor: '#EF5350',
                        pointHoverBorderColor: "#fff",
                        pointHoverBorderWidth: 2,
                        pointRadius: 3,
                        data: [65, 59, 80, 81, 56, 55, 40]
                    },
                    {
                        label: "My Second dataset",
                        fill: true,
                        borderWidth: 2,
                        backgroundColor: 'transparent',
                        borderColor: '#42A5F5',
                        pointBorderColor: "#fff",
                        pointBackgroundColor: '#42A5F5',
                        pointBorderWidth: 2,
                        pointHoverBackgroundColor: '#42A5F5',
                        pointHoverBorderColor: "#fff",
                        pointHoverBorderWidth: 2,
                        pointRadius: 3,
                        data: [28, 48, 40, 19, 86, 27, 90]
                    }
                ]
            }
        });
    }

    // Chart examples: Bar chart
    if ($(".chart_barchart").length) {

        Chart.defaults.global.responsive = true;
        Chart.defaults.global.legend.display = false;
        
        var ctx = $(".chart_barchart").get(0).getContext("2d");
        var chartBarChart = new Chart(ctx, {
            type: "bar",
            data: {
                labels: ["January", "February", "March", "April", "May", "June", "July"],
                datasets: [
                    {
                        label: "My First dataset",
                        fill: true,
                        borderWidth: 1,
                        backgroundColor: '#EF9A9A',
                        borderColor: '#EF5350',
                        pointBorderColor: "#fff",
                        pointBackgroundColor: '#EF5350',
                        pointBorderWidth: 2,
                        pointHoverBackgroundColor: '#EF5350',
                        pointHoverBorderColor: "#fff",
                        pointHoverBorderWidth: 2,
                        pointRadius: 3,
                        data: [65, 59, 80, 81, 56, 55, 40]
                    },
                    {
                        label: "My Second dataset",
                        fill: true,
                        borderWidth: 1,
                        backgroundColor: '#90CAF9',
                        borderColor: '#42A5F5',
                        pointBorderColor: "#fff",
                        pointBackgroundColor: '#42A5F5',
                        pointBorderWidth: 2,
                        pointHoverBackgroundColor: '#42A5F5',
                        pointHoverBorderColor: "#fff",
                        pointHoverBorderWidth: 2,
                        pointRadius: 3,
                        data: [28, 48, 40, 19, 86, 27, 90]
                    }
                ]   
            }
        }, {
            barStrokeWidth: 1
        });
    }

    // Chart examples: Radar chart
    if ($(".chart_radarchart").length) {

        Chart.defaults.global.responsive = true;
        Chart.defaults.global.legend.display = false;
        
        var ctx = $(".chart_radarchart").get(0).getContext("2d");
        var chartBarChart = new Chart(ctx, {
            type: "radar",
            data: {
                labels: ["January", "February", "March", "April", "May", "June", "July"],
                datasets: [
                    {
                        label: "My First dataset",
                        fill: true,
                        borderWidth: 2,
                        backgroundColor: 'rgba(255, 205, 210, .25)',
                        borderColor: '#EF5350',
                        pointBorderColor: "#fff",
                        pointBackgroundColor: '#EF5350',
                        pointBorderWidth: 2,
                        pointHoverBackgroundColor: '#EF5350',
                        pointHoverBorderColor: "#fff",
                        pointHoverBorderWidth: 2,
                        pointRadius: 3,
                        data: [65, 59, 80, 81, 56, 55, 40]
                    },
                    {
                        label: "My Second dataset",
                        fill: true,
                        borderWidth: 2,
                        backgroundColor: 'rgba(187, 222, 251, .25)',
                        borderColor: '#42A5F5',
                        pointBorderColor: "#fff",
                        pointBackgroundColor: '#42A5F5',
                        pointBorderWidth: 2,
                        pointHoverBackgroundColor: '#42A5F5',
                        pointHoverBorderColor: "#fff",
                        pointHoverBorderWidth: 2,
                        pointRadius: 3,
                        data: [28, 48, 40, 19, 86, 27, 90]
                    }
                ]   
            }
        });
    }

    // Chart examples: Polar Area chart
    if ($(".chart_polarareachart").length) {

        Chart.defaults.global.responsive = true;
        Chart.defaults.global.legend.display = false;
        
        var ctx = $(".chart_polarareachart").get(0).getContext("2d");
        var chartPolarAreaChart = new Chart(ctx, {
            type: "polarArea", 
            data: {
                datasets: [{
                    data: [290, 90, 140, 190],
                    backgroundColor: [
                        '#EF5350',
                        '#FFCA28',
                        '#66BB6A',
                        '#42A5F5'
                    ],
                    hoverBackgroundColor: [
                        '#F44336',
                        '#FFC107',
                        '#4CAF50',
                        '#2196F3'
                    ],
                    label: ["Red", "Amber", "Green", "Blue"],
                    borderWidth: 0
                }], 
                labels: ["Red", "Amber", "Green", "Blue"]
            }
        })
    }

    // Chart examples: Pie chart
    if ($(".chart_radarchart").length) {

        Chart.defaults.global.responsive = true;
        Chart.defaults.global.legend.display = false;
        
        var ctx = $(".chart_piechart").get(0).getContext("2d");
        var chartPieChart = new Chart(ctx, {
            type: "pie",
            data: {
                datasets: [{
                    data: [150, 50, 100, 120],
                    backgroundColor: [
                        '#EF5350',
                        '#FFCA28',
                        '#66BB6A',
                        '#42A5F5'
                    ],
                    hoverBackgroundColor: [
                        '#F44336',
                        '#FFC107',
                        '#4CAF50',
                        '#2196F3'
                    ],
                    labels: ["Red", "Amber", "Green", "Blue"]
                }],
                labels: ["Red", "Amber", "Green", "Blue"]
            }
        });
    }

    // Chart examples: Doughnut chart
    if ($(".chart_doughnutchart").length) {

        Chart.defaults.global.responsive = true;
        Chart.defaults.global.legend.display = false;
        
        var ctx = $(".chart_doughnutchart").get(0).getContext("2d");
        var chartDoughnutChart = new Chart(ctx, {
            type: "doughnut",
            data: {
                datasets: [{
                    data: [150, 50, 100, 120],
                    backgroundColor: [
                        '#EF5350',
                        '#FFCA28',
                        '#66BB6A',
                        '#42A5F5'
                    ],
                    hoverBackgroundColor: [
                        '#F44336',
                        '#FFC107',
                        '#4CAF50',
                        '#2196F3'
                    ],
                    labels: ["Red", "Amber", "Green", "Blue"]
                }],
                labels: ["Red", "Amber", "Green", "Blue"]
            }
        });
    }

    // Chart examples: Bubble chart
    if ($(".chart_bubble").length) {

        Chart.defaults.global.responsive = true;
        Chart.defaults.global.legend.display = false;
        
        var ctx = $(".chart_bubble").get(0).getContext("2d");
        var chartDoughnutChart = new Chart(ctx, {
            type: "bubble",
            data: {
                datasets: [
                    {
                        label: 'First Dataset',
                        data: [
                            {
                                x: 20,
                                y: 30,
                                r: 15
                            },
                            {
                                x: 10,
                                y: 40,
                                r: 10
                            },
                            {
                                x: 15,
                                y: 30,
                                r: 20
                            },
                            {
                                x: 30,
                                y: 25,
                                r: 10
                            },
                            {
                                x: 35,
                                y: 25,
                                r: 12
                            },
                            {
                                x: 30,
                                y: 7,
                                r: 5
                            },
                            {
                                x: 34,
                                y: 22,
                                r: 20
                            },
                            {
                                x: 16,
                                y: 40,
                                r: 10
                            },
                            {
                                x: 23,
                                y: 12,
                                r: 12
                            },
                            {
                                x: 30,
                                y: 20,
                                r: 15
                            }
                        ],
                        backgroundColor:"#EF5350",
                        hoverBackgroundColor: "#F44336",
                    }]
            }
        });
    }


    /**
     * Peity.js
     */

    // Dashboards: Stats

    var dashboardStatsDonut = $('.dashboard__stats_alt__item__circle__donut');

    if ( dashboardStatsDonut.length ) {

        // Base donut styles

        $.fn.peity.defaults.donut = {
            delimiter: null,
            fill: ["#EF5350", "#ddd"],
            height: null,
            innerRadius: 68,
            radius: 70,
            width: null
        };

        dashboardStatsDonut.each(function () {
            var $this = $(this);

            var updateChart = $this.peity('donut');
            var text = "";
            var i = 0;
            var str = $this.html();
            var arr = str.split("/");
            var value = arr[0];
            var maxValue = arr[1];
            var step = value/50;

            function myLoop() {
                setTimeout(function () {

                    text = i + "/" + maxValue;

                    updateChart.text(text)
                        .change()

                    i = i + step;

                    if (i <= value) myLoop();

                }, 10)
            }
            myLoop();
        });

    }

    // Peity examples: Bar chart

    var peityBar = $('.peity_bar');

    if ( peityBar.length ) {

        var updatingPeityBar = peityBar.peity('bar', {
            fill: ['#42A5F5'],
            height: 100,
            width: '100%'
        });

        setInterval(function() {
          var random = Math.round(Math.random() * 10)
          var values = updatingPeityBar.text().split(",")
          values.shift()
          values.push(random)

          updatingPeityBar
            .text(values.join(","))
            .change()
        }, 1000);

    }

    // Peity examples: Line chart

    var peityLine = $('.peity_line');

    if ( peityLine.length ) {

        var updatingPeityLine = peityLine.peity('line', {
            fill: '#EF5350',
            stroke: '#EF5350',
            strokeWidth: 1,
            height: 100,
            width: '100%'
        });

        setInterval(function() {
          var random = Math.round(Math.random() * 10)
          var values = updatingPeityLine.text().split(",")
          values.shift()
          values.push(random)

          updatingPeityLine
            .text(values.join(","))
            .change()
        }, 1000);

    }

    // Peity examples: Pie chart

    var peityPie = $('.peity_pie');

    if ( peityPie.length ) {

        peityPie.peity("pie", {
            fill: ['#FFCA28', '#f9f9f9'],
            radius: 70
        });

    }

    // Peity examples: Donut chart

    var peityDonut = $('.peity_donut');

    if ( peityDonut.length ) {

        peityDonut.peity("donut", {
            fill: ['#FFCA28', '#f9f9f9'],
            radius: 70
        });

    }


    /**
     * JQV maps
     */

    // Resize map

    function jqvMapSize(elem) {
        var $this = elem;
        var width = $this.width();
        var height = width * 0.6;

        $this.css({
            'height': height + 'px'
        });
    };

    // World map

    var jqvMapWorld = $('#jqv-map_world');

    if ( jqvMapWorld.length ) {

        // Resize map
        jqvMapSize(jqvMapWorld);

        // Init map
        jqvMapWorld.vectorMap({
            map: 'world_en',
            backgroundColor: 'transparent',
            color: '#81C784',
            borderColor: '#fff',
            hoverColor: '#4CAF50',
            selectedColor: '#4CAF50',
            enableZoom: false,
            selectedRegions: ['US'],
            onLabelShow: function(event, label, code, region) {
                var number = Math.floor(Math.random() * 1000);
                var message = 'Total users: ' + number;

                label.html('<div class="map-tooltip">' + message + '</div>');
            }
        });
    }

    // Europe map

    var jqvMapEurope = $('#jqv-map_europe');

    if ( jqvMapEurope.length ) {

        // Resize map
        jqvMapSize(jqvMapEurope);

        // Init map
        jqvMapEurope.vectorMap({
            map: 'europe_en',
            backgroundColor: 'transparent',
            color: '#81C784',
            borderColor: '#fff',
            hoverColor: '#4CAF50',
            selectedColor: '#4CAF50',
            enableZoom: false
        });
    }

    // Usa map

    var jqvMapUsa = $('#jqv-map_usa');

    if ( jqvMapUsa.length ) {

        // Resize map
        jqvMapSize(jqvMapUsa);

        // Init map
        jqvMapUsa.vectorMap({
            map: 'usa_en',
            backgroundColor: 'transparent',
            color: '#81C784',
            borderColor: '#fff',
            hoverColor: '#4CAF50',
            selectedColor: '#4CAF50',
            enableZoom: false
        });
    }

    // Germany map

    var jqvMapGermany = $('#jqv-map_germany');

    if ( jqvMapGermany.length ) {

        // Resize map
        jqvMapSize(jqvMapGermany);

        // Init map
        jqvMapGermany.vectorMap({
            map: 'germany_en',
            backgroundColor: 'transparent',
            color: '#81C784',
            borderColor: '#fff',
            hoverColor: '#4CAF50',
            selectedColor: '#4CAF50',
            enableZoom: false
        });
    }

    // Russia map

    var jqvMapRussia = $('#jqv-map_russia');

    if ( jqvMapRussia.length ) {

        // Resize map
        jqvMapSize(jqvMapRussia);

        // Init map
        jqvMapRussia.vectorMap({
            map: 'russia_en',
            backgroundColor: 'transparent',
            color: '#81C784',
            borderColor: '#fff',
            hoverColor: '#4CAF50',
            selectedColor: '#4CAF50',
            enableZoom: false
        });
    }

    // France map

    var jqvMapFrance = $('#jqv-map_france');

    if ( jqvMapFrance.length ) {

        // Resize map
        jqvMapSize(jqvMapFrance);

        // Init map
        jqvMapFrance.vectorMap({
            map: 'france_fr',
            backgroundColor: 'transparent',
            color: '#81C784',
            borderColor: '#fff',
            hoverColor: '#4CAF50',
            selectedColor: '#4CAF50',
            enableZoom: false
        });
    }

    // Canada map

    var jqvMapCanada = $('#jqv-map_canada');

    if ( jqvMapCanada.length ) {

        // Resize map
        jqvMapSize(jqvMapCanada);

        // Init map
        jqvMapCanada.vectorMap({
            map: 'canada_en',
            backgroundColor: 'transparent',
            color: '#81C784',
            borderColor: '#fff',
            hoverColor: '#4CAF50',
            selectedColor: '#4CAF50',
            enableZoom: false
        });
    }


    /**
    * Fullcalendar
    */

    /*** Basic view ***/

    var fullcalendar = $('#fullcalendar_basic');

    if ( fullcalendar.length ) {

        fullcalendar.fullCalendar({
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,basicWeek,basicDay'
            },
            defaultDate: '2017-02-12',
            navLinks: true, // can click day/week names to navigate views
            editable: true,
            eventLimit: true, // allow "more" link when too many events
            events: [
                {
                    title: 'All Day Event',
                    start: '2017-02-01'
                },
                {
                    title: 'Long Event',
                    start: '2017-02-07',
                    end: '2017-02-10'
                },
                {
                    id: 999,
                    title: 'Repeating Event',
                    start: '2017-02-09T16:00:00'
                },
                {
                    id: 999,
                    title: 'Repeating Event',
                    start: '2017-02-16T16:00:00'
                },
                {
                    title: 'Conference',
                    start: '2017-02-11',
                    end: '2017-02-13'
                },
                {
                    title: 'Meeting',
                    start: '2017-02-12T10:30:00',
                    end: '2017-02-12T12:30:00'
                },
                {
                    title: 'Lunch',
                    start: '2017-02-12T12:00:00'
                },
                {
                    title: 'Meeting',
                    start: '2017-02-12T14:30:00'
                },
                {
                    title: 'Happy Hour',
                    start: '2017-02-12T17:30:00'
                },
                {
                    title: 'Dinner',
                    start: '2017-02-12T20:00:00'
                },
                {
                    title: 'Birthday Party',
                    start: '2017-02-13T07:00:00'
                },
                {
                    title: 'Click for Google',
                    url: 'http://google.com/',
                    start: '2017-02-28'
                }
            ]
        });

    }

    /*** List view ***/

    var fullcalendarListView = $('#fullcalendar_list');

    if ( fullcalendarListView.length ) {

        fullcalendarListView.fullCalendar({
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'listDay,listWeek,month'
            },

            // customize the button names,
            // otherwise they'd all just say "list"
            views: {
                listDay: { buttonText: 'list day' },
                listWeek: { buttonText: 'list week' }
            },

            defaultView: 'listWeek',
            defaultDate: '2017-02-12',
            navLinks: true, // can click day/week names to navigate views
            editable: true,
            eventLimit: true, // allow "more" link when too many events
            events: [
                {
                    title: 'All Day Event',
                    start: '2017-02-01'
                },
                {
                    title: 'Long Event',
                    start: '2017-02-07',
                    end: '2017-02-10'
                },
                {
                    id: 999,
                    title: 'Repeating Event',
                    start: '2017-02-09T16:00:00'
                },
                {
                    id: 999,
                    title: 'Repeating Event',
                    start: '2017-02-16T16:00:00'
                },
                {
                    title: 'Conference',
                    start: '2017-02-11',
                    end: '2017-02-13'
                },
                {
                    title: 'Meeting',
                    start: '2017-02-12T10:30:00',
                    end: '2017-02-12T12:30:00'
                },
                {
                    title: 'Lunch',
                    start: '2017-02-12T12:00:00'
                },
                {
                    title: 'Meeting',
                    start: '2017-02-12T14:30:00'
                },
                {
                    title: 'Happy Hour',
                    start: '2017-02-12T17:30:00'
                },
                {
                    title: 'Dinner',
                    start: '2017-02-12T20:00:00'
                },
                {
                    title: 'Birthday Party',
                    start: '2017-02-13T07:00:00'
                },
                {
                    title: 'Click for Google',
                    url: 'http://google.com/',
                    start: '2017-02-28'
                }
            ]
        });

    }


    /**
     * Tooltips and popovers
     */

    var tooltips = $('[data-toggle="tooltip"]');

    if ( tooltips.length ) {
        tooltips.tooltip();
    }


    /**
     * Smart alerts
     */

    var smartAlert = $('.smart-alert');

    if ( smartAlert.length ) {

        // Init smart alerts
        var smartAlerts = new SmartAlerts();

        // Generate alerts (ui_alerts.html example)
            smartAlert.each(function() {
                var alertType = $(this).data("alert-type");
                var alertContent = $(this).data("alert-content");

                $(this).click(function() {
                    smartAlerts.generate(alertType, alertContent);
                    return false;
                });
            });
            
    }


    /**
     * Gallery: Isotope
     */

    var galleryRow = $('#gallery__row');

    if ( galleryRow.length ) {

        // Init isotope plugin

        var galleryRowGrid = galleryRow.isotope({
            itemSelector: '#gallery__row > [class*="col-"]',
            layoutMode: 'fitRows',
            getSortData: {
                category: '[data-category]'
            }
        });

        // layout Isotope after each image loads
        galleryRowGrid.imagesLoaded().progress( function() {
          galleryRowGrid.isotope('layout');
        });

        var galleryToolbar = $('#gallery__toolbar');

        // Filter items

        galleryToolbar.on('click', '[data-filter]', function() {
            var $this = $(this);
            var filterValue = $this.data('filter');

            galleryRowGrid.isotope({
                filter: filterValue
            });
        });

        // Sort items

        galleryToolbar.on('click', '[data-sort-by]', function() {
            var $this = $(this);
            var sortByValue = $this.data('sort-by');

            galleryRowGrid.isotope({
                sortBy: sortByValue
            });
        });

        // Modals

        var galleryModalLink = $('[href="#gallery__modal"]');
        var galleryModal = $('#gallery__modal');
        var galleryModalImg = $('#gallery__modal__img');

        galleryModalLink.on('click', function() {
            var $this = $(this);
            var imgSrc = $this.parents('.thumbnail').find('img').attr('src');

            galleryModalImg.attr('src', imgSrc);
        });

    }


    /**
     * Theme setup
     */

    var $body = $('body');
    var settingsButton = '<button id="kite-settings__btn" class="btn btn-floating btn-primary" data-toggle="dropdown"><i class="fa fa-cogs"></i></button>';
      var settingsMenu = '<div class="dropdown-menu" id="kite-settings__menu">';
           settingsMenu += '<h2>Color options:</h2>';
           settingsMenu += '<ul>';
             settingsMenu += '<li><a href="#" data-color="red" title="Red color" class="brand-red"></a></li>';
             settingsMenu += '<li><a href="#" data-color="pink" title="Pink color" class="brand-pink"></a></li>';
             settingsMenu += '<li><a href="#" data-color="purple" title="Purple color" class="brand-purple"></a></li>';
             settingsMenu += '<li><a href="#" data-color="deep-purple" title="Deep purple color" class="brand-deep-purple"></a></li>';
             settingsMenu += '<li><a href="#" data-color="indigo" title="Indigo color" class="brand-indigo"></a></li>';
             settingsMenu += '<li class="active"><a href="#" data-color="blue" title="Blue color" class="brand-blue"></a></li>';
             settingsMenu += '<li><a href="#" data-color="light-blue" title="Light blue color" class="brand-light-blue"></a></li>';
             settingsMenu += '<li><a href="#" data-color="cyan" title="Cyan color" class="brand-cyan"></a></li>';
             settingsMenu += '<li><a href="#" data-color="teal" title="Teal color" class="brand-teal"></a></li>';
             settingsMenu += '<li><a href="#" data-color="green" title="Green color" class="brand-green"></a></li>';
             settingsMenu += '<li><a href="#" data-color="light-green" title="Light green color" class="brand-light-green"></a></li>';
             settingsMenu += '<li><a href="#" data-color="lime" title="Lime color" class="brand-lime"></a></li>';
             settingsMenu += '<li><a href="#" data-color="yellow" title="Yellow color" class="brand-yellow"></a></li>';
             settingsMenu += '<li><a href="#" data-color="amber" title="Amber color" class="brand-amber"></a></li>';
             settingsMenu += '<li><a href="#" data-color="orange" title="Orange color" class="brand-orange"></a></li>';
             settingsMenu += '<li><a href="#" data-color="deep-orange" title="Deep orange color" class="brand-deep-orange"></a></li>';
             settingsMenu += '<li><a href="#" data-color="brown" title="Brown color" class="brand-brown"></a></li>';
             settingsMenu += '<li><a href="#" data-color="grey" title="Grey color" class="brand-grey"></a></li>';
             settingsMenu += '<li><a href="#" data-color="blue-grey" title="Blue grey color" class="brand-blue-grey"></a></li>';
             settingsMenu += '<li><a href="#" data-color="original" title="Original color" class="brand-original"></a></li>';
           settingsMenu += '</ul>';
         settingsMenu += '</div>';
   var settingsContent = '<div class="dropdown" id="kite-settings">' + settingsButton + settingsMenu + '</div>';

   // $body.prepend(settingsContent);

    // Set new color scheme

    $body.on('click', '#kite-settings__menu a', function(e) {
        e.preventDefault();

        var $this = $(this);
        var color = $this.data('color');
        var linkLink = '<link rel="stylesheet" href="assets/css/theme_' + color + '.css">';

        localStorage.setItem('kiteColor', color);

        $this.parent('li').addClass('active').siblings('li').removeClass('active');

        $('[href*="assets/css/theme"]').after(linkLink);
    });

    // Get saved color scheme

    /* var kiteColor = localStorage.getItem("kiteColor");

    if ( kiteColor ) {
        $('[href*="assets/css/theme"]').attr('href', 'assets/css/theme_' + kiteColor + '.css');
    } */

});


/**
 * Google map
 */

var map;

function initMap() {

  // Create a styles array
  var styles = [{"elementType":"geometry","stylers":[{"color":"#f9f9f9"}]},{"elementType":"labels.icon","stylers":[{"visibility":"off"}]},{"elementType":"labels.text.fill","stylers":[{"color":"#616161"}]},{"elementType":"labels.text.stroke","stylers":[{"color":"#f5f5f5"}]},{"featureType":"administrative.land_parcel","elementType":"labels.text.fill","stylers":[{"color":"#bdbdbd"}]},{"featureType":"poi","elementType":"geometry","stylers":[{"color":"#eeeeee"}]},{"featureType":"poi","elementType":"labels.text.fill","stylers":[{"color":"#757575"}]},{"featureType":"poi.park","elementType":"geometry","stylers":[{"color":"#e5e5e5"}]},{"featureType":"poi.park","elementType":"labels.text.fill","stylers":[{"color":"#9e9e9e"}]},{"featureType":"road","elementType":"geometry","stylers":[{"color":"#ffffff"}]},{"featureType":"road.arterial","elementType":"labels.text.fill","stylers":[{"color":"#757575"}]},{"featureType":"road.highway","elementType":"geometry","stylers":[{"color":"#dadada"}]},{"featureType":"road.highway","elementType":"labels.text.fill","stylers":[{"color":"#616161"}]},{"featureType":"road.local","elementType":"labels.text.fill","stylers":[{"color":"#9e9e9e"}]},{"featureType":"transit.line","elementType":"geometry","stylers":[{"color":"#e5e5e5"}]},{"featureType":"transit.station","elementType":"geometry","stylers":[{"color":"#eeeeee"}]},{"featureType":"water","elementType":"geometry","stylers":[{"color":"#ededed"}]},{"featureType":"water","elementType":"labels.text.fill","stylers":[{"color":"#9e9e9e"}]}];

  // Create a new StyledMapType object, passing it the array of styles,
  // as well as the name to be displayed on the map type control.
  var styledMap = new google.maps.StyledMapType(styles,
    {name: "Styled Map"});

  // Create a map object, and include the MapTypeId to add
  // to the map type control.
  var mapOptions = {
    zoom: 4,
    center: new google.maps.LatLng(48.2285361, 15.00686),
    mapTypeControlOptions: {
      mapTypeIds: [google.maps.MapTypeId.ROADMAP, 'map_style']
    },
    scrollwheel: false,
    draggable: !("ontouchend" in document)
  };

  // Create map #1 & map #2
  var map1 = new google.maps.Map(document.getElementById('google-map_1'),
    mapOptions);
  var map2 = new google.maps.Map(document.getElementById('google-map_2'),
    mapOptions);

  // Get marker images
  var markerImage = 'assets/img/icons/icon_marker_accent.png';
  var markerImageActive = 'assets/img/icons/icon_marker_primary.png';

  // Create markers
  var markers = {
    "Paris": [48.8588377, 2.2775169, markerImageActive],
    "Berlin": [52.5072111, 13.1459617, markerImage],
    "Warsaw": [52.2326062, 20.7810109, markerImage],
    "Budapest": [47.4811282, 18.9902184, markerImage],
    "Bucharest": [44.4377401, 25.9545524, markerImage],
    "Milan": [45.4626482, 9.0376472, markerImage],
    "Lyublyana": [45.9204763, 14.3947208, markerImage]
  };

  var markersArr = [];

  for(key in markers) {

    var marker = new google.maps.Marker({
      map: map2,
      position: {lat: markers[key][0], lng: markers[key][1]},
      title: key,
      icon: markers[key][2]
    });

    markersArr.push(marker);
    toggleActiveMarker(marker, key);

    // Create only 1 marker for map #1

    if ( key == "Paris" ) {
        var marker = new google.maps.Marker({
          map: map1,
          position: {lat: markers[key][0], lng: markers[key][1]},
          title: key,
          icon: markers[key][2]
        });
    }

  };


  // Change active marker on click
  function toggleActiveMarker(marker, key) {

    marker.addListener('click', function() {

      for (var i = 0; i < markersArr.length; i++) {
        markersArr[i].setIcon(markerImage);
      }

      marker.setIcon(markerImageActive);

      $("[data-place]").removeClass('show').addClass('hidden')
        .filter("[data-place='" + key + "']").toggleClass('show hidden');

    });
  }

  //Associate the styled map with the MapTypeId and set it to display.

  map1.mapTypes.set('map_style', styledMap);
  map1.setMapTypeId('map_style');

  map2.mapTypes.set('map_style', styledMap);
  map2.setMapTypeId('map_style');

}