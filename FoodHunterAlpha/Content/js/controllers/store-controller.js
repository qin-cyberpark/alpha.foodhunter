(function () {
    'use strict';

    angular
        .module('food-hunters')
        .controller('storeController', storeController);

    storeController.$inject = ['$http'];

    function storeController($http) {
        /* jshint validthis:true */
        var store = this;

        /* init */
        store.init = function () {
            store.cart.loadFromCookie();
        }

        /*cart*/
        store.cart = {
            itms: [],
            qty: 0,
            amt: 0,
            add: function (nwItem) {
                console.log(nwItem);
                this.qty++;
                this.amt += nwItem.price;
                console.log("this is:", this);
                var added = false;

                $.each(this.itms, function (idx, item) {
                    //existing item
                    if (item.i == nwItem.id) {
                        item.q++;
                        added = true;
                        return false;
                    }
                })

                if (!added) {
                    this.itms.push({ i: nwItem.id, n: nwItem.description, q: 1, p: nwItem.price });
                }

                //new item
                this.writeToCookie();
            },
            empty: function () {
                this.itms = [];
                this.qty = 0;
                this.amt = 0;
                Cookies.remove("cart");
            },
            remove: function (itemId) {
                var delIdx = -1;
                $.each(this.itms, function (idx, item) {
                    if (item.i == itemId) {
                        store.cart.qty -= item.q;
                        store.cart.amt -= item.p * item.q;
                        delIdx = store.cart.itms.indexOf(item);
                    }
                })

                if (delIdx > -1) {
                    store.cart.itms.splice(delIdx, 1);
                }
                this.writeToCookie();
            },
            plusOne: function (itemId) {
                $.each(this.itms, function (idx, item) {
                    if (item.i == itemId && item.q < 99) {
                        item.q++;
                        store.cart.qty++;
                        store.cart.amt += item.p;
                    }
                })
                this.writeToCookie();
            },
            minusOne: function (itemId) {
                var delIdx = -1;
                $.each(this.itms, function (idx, item) {
                    if (item.i == itemId && item.q > 0) {
                        item.q--;
                        store.cart.qty--;
                        store.cart.amt -= item.p;
                    }
                })

                this.writeToCookie();
            },
            loadFromCookie: function () {
                var str = Cookies.get('cart');
                if (!str) {
                    return;
                }
                var c = $.parseJSON(str);
                this.itms = c.itms;
                this.qty = c.qty;
                this.amt = c.amt;
            },
            writeToCookie: function () {
                Cookies.set("cart", this, { expires: 14 });
            }
        }
    }
})();
