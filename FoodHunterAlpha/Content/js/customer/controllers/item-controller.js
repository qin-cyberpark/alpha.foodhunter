(function () {
    'use strict';

    angular
        .module('food-hunters')
        .controller('itemController', itemController);

    itemController.$inject = ['$http'];

    function itemController($http) {
        /* jshint validthis:true */
        var vm = this;

        vm.init = function (restId, cateId) {
            //load items
            $http.get('/api/' + restId + '/' + cateId).success(function (result) {
                if (result) {
                    //show items
                    $.each(result, function (idx, item) {
                        $.each(item.optionGroups, function (idx, grp) {
                            $.each(grp.itemOptions, function (idx, opt) {
                                if (opt.isDefault) {
                                    opt.selected = true;
                                } else {
                                    opt.selected = false;
                                }
                            })
                        })
                    });
                    vm.items = result;
                }
            }).error(function () {
            });
        }

        vm.optionChanged = function (item, grp, currOpt) {
            var recover = currOpt.selected;
            var selected = !currOpt.selected;
            $.each(grp.itemOptions, function (idx, opt) {
                opt.selected = false;
                if (recover && opt.isDefault) {
                    opt.selected = true;
                }
            })
            currOpt.selected = selected;
        }
    }
})();
