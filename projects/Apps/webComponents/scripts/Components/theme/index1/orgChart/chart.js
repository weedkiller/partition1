﻿var verticalOrgChart;
(function ($$) {
    (function ($) {

        verticalOrgChart = Class.create(
        {
            initialize: function () { }
        });

        verticalOrgChart.loadOrgs = function (parentID) {
            oc_style = {
                container: parentID,         // name of the DIV where the chart will be drawn
                vline: 10,                     // size of the smallest vertical line of connectors
                hline: 10,                     // size of the smallest horizontal line of connectors
                inner_padding: 10,                     // space from text to box border
                box_color: '#eee',                 // fill color of boxes
                box_color_hover: '#faa',                 // fill color of boxes when mouse is over them
                box_border_color: '#aaa',                 // stroke color of boxes
                line_color: '#f44',                 // color of connectors
                title_color: '#000',                 // color of titles
                subtitle_color: '#707',                 // color of subtitles
                title_font_size: 12,                     // size of font used for displaying titles inside boxes
                subtitle_font_size: 10,                     // size of font used for displaying subtitles inside boxes
                title_char_size: [6, 12],              // size (x, y) of a char of the font used for displaying titles
                subtitle_char_size: [5, 10],              // size (x, y) of a char of the font used for displaying subtitles
                max_text_width: 15,                     // max width (in chars) of each line of text ('0' for no limit) 
                box_click_handler: oc_box_click_handler   // handler (function) called on click on boxes (set to null if no handler)
            };
            OC_DEBUG = false;

            function oc_box_click_handler(event, box) {
                if (box.oc_id !== undefined)
                    alert('clicked on node with ID = ' + box.oc_id);
            }


            $.ajax(
            {
                url: 'workflow/getusers'
            }).done(function (data) {

                oc_data = {
                    title: 'My Org Chart',
                    root: data[0]
                };

                oc_render();
            }); //ajax call

        }


    } (jQuery));
} (Prototype));
