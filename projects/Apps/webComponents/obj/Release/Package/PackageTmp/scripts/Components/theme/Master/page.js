﻿
    (function ($) {

        function theme() {

            $('.Hsection').undelegate(this, "click").delegate(this, "click", function (e) {
                var me = this;

                var hideAll = $('.Hsection-content').fadeOut();
                $.when(hideAll)
            .done(function () {

                $(me).find('div').each(function (index) {

                    if ($(this).hasClass('Hsection-content')) {
                        if ($(this).is(":visible"))
                            $(this).fadeOut(function () { });
                        else
                            $(this).fadeIn(function () { });
                    }

                });
            });

                e.stopPropagation();
                return false;

            }); //.section click
            $(".Hsection-header:not(:eq(0))").next().hide();

            var i = 0;
        };
        theme();

    } (jQuery));
