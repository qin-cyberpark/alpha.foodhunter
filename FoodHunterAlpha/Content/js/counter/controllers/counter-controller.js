(function () {
    'use strict';

    angular
        .module('food-hunters-counter')
        .controller('counterController', counterController);

    counterController.$inject = ['$http'];

    function counterController($http) {
        /* jshint validthis:true */
        var vm = this;
        vm.orderIdsInQueue = null;
        vm.currentOrder = null;

        vm.audio_notification = new Audio('/content/new_order.mp3');
        vm.init = function () {
            vm.initConnect();
            vm.loadOrderQueue();
        }


        vm.loadOrderQueue = function () {
            //load order in queue;
            $http.get('/api/15/order/queue').success(function (result) {
                if (result) {
                    //show order id
                    vm.orderIdsInQueue = result;
                    if (!vm.currentOrder) {
                        vm.loadOrder(vm.orderIdsInQueue[0]);
                    }
                }
            }).error(function () {
            });
        }

        vm.initConnect = function () {
            $.connection.hub.logging = true;
            // Declare a proxy to reference the hub.
            var myCoffee = $.connection.centerHub;
            // Create a function that the hub can call to broadcast messages.
            myCoffee.client.loadOrderQueue = function () {
                vm.audio_notification.play();
                vm.loadOrderQueue();
            }
            $.connection.hub.start();
        }

        vm.loadOrder = function (id) {

            //load order in queue;
            $http.get('/api/15/order/' + id).success(function (result) {
                if (result) {
                    console.log(result);
                    //show order id
                    vm.currentOrder = result;
                }
            }).error(function () {
            });
        }

        vm.completeOrder = function (id) {
            //load order in queue;
            $http.get('/api/15/complete/' + id).success(function (result) {
                console.log(result);
                if (result) {
                    //show order id
                    vm.currentOrder = null;
                    vm.loadOrderQueue();
                }
            }).error(function () {
            });
        }
    }
})();
