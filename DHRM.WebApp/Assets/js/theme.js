// ========
// Theme.js
// ========

// Contains common JS code used throughout the Kite theme.
// Required on a production website.


$(function() {

    /*** Body ***/

    $('body').addClass('body_loaded');

    /*** Sidebar ***/

    // Sidebar: Fetch links
    $.getJSON("sidebar.json", function(data) {
        var $sidebarNav = $('#sidebar__nav'),
            sidebarNavHtml = '';

        for (var i = 0; i < data.length; i++) {
            var title = data[i]['title'],
                links = data[i]['links'];

            // Titles
            sidebarNavHtml += '<li class="sidebar-nav__heading">' + title + '</li>';

            // Links
            for (var n = 0; n < links.length; n++) {
                var icon = links[n]['icon'],
                    url = links[n]['url'],
                    caption = links[n]['caption'],
                    dropdown = links[n]['dropdown'];

                if ( !dropdown ) {
                    sidebarNavHtml += '<li><a href="' + url + '"><i class="' + icon + '"></i> ' + caption + '</a></li>';
                } else {
                    var id = 'sidebar-nav__dropdown_' + i + n,
                        dropdownLinks = ''; 

                    for (var k = 0; k < dropdown.length; k++) {
                        dropdownLinks += '<li><a href="' + dropdown[k]['url'] + '">' + dropdown[k]['caption'] + '</a></li>';
                    }

                    sidebarNavHtml += '<li class="sidebar-nav__dropdown">';
                    sidebarNavHtml += '<a href="#' + id + '" role="button" data-toggle="collapse" aria-expanded="false" aria-controls="' + id + '">';
                    sidebarNavHtml += '<i class="' + icon + '"></i> ' + caption;
                    sidebarNavHtml += '</a>';
                    sidebarNavHtml += '<ul class="sidebar-nav__submenu collapse" id="' + id + '">';
                    sidebarNavHtml += dropdownLinks;
                    sidebarNavHtml += '</ul>';
                }
            }
        }

        // Embed links into sidebar
        $sidebarNav.html('<ul class="sidebar__nav">' + sidebarNavHtml + '</ul>');
    
        // Highlight active links & toggle active dropdowns

        var currentUrl = window.location.href,
            currectPageUrl = currentUrl.split('/'),
            currectPageUrl = currectPageUrl[currectPageUrl.length - 1];

        if ( !currectPageUrl ) {
            currectPageUrl = 'index.html';
        }

        var currentLi = $('#sidebar__nav').find('[href="' + currectPageUrl + '"]').parent('li');
        currentLi.addClass('active');
        currentLi.closest('.sidebar-nav__dropdown').addClass("active");
        currentLi.closest('.collapse').collapse('toggle');
    });

    // Toggle sidebar dropdowns menus

    $('#sidebar__nav').on('show.bs.collapse', '.collapse', function() {
        var $this = $(this);

        $('#sidebar__nav').find('.collapse').not($this).each(function() {
            $(this).collapse('hide');
        });

    });

    // Sidebar: Toggle sidebar
    $("#sidebar__toggle, .sidebar__close").click(function() {
        $(".wrapper").toggleClass("alt");
        return false;
    });

    // Sidebar: Init perfect scrollbar
    $(".sidebar").perfectScrollbar({
        suppressScrollX: true
    });


    /*** Footer ***/

    var currentYear = new Date().getFullYear();
    $('.page__footer__year').text(currentYear);


});