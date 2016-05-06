(function () {
    'use strict';

    angular.module('food-hunters', []);

    $("a[js-href]").each(function (idx, lnk) {
        $(lnk).click(function () {
            window.location = $(lnk).attr('js-href');
        });
    });

})();