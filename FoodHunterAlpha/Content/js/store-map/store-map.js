function StoreMap(container, stores, setting) {
    var self = this;

    //default setting
    self.defaultSetting = {
        center: { lat: -36.8576757, lng: 174.7591993 },
        zoom: 13,
        mapTypeControl: false
    };

    //map container
    self.container = container;
    //stores
    self.stores = stores;
    //current setting
    self.setting = $.extend({}, self.defaultSetting, setting);

    //map object
    self.map = null;

    /* init function*/
    self.init = function () {
        //init
        self.map = new google.maps.Map(self.container, self.setting);
        self.putCurrentPositionMarker();
        self.putStoreMarker(self.stores);
    }

    /* info windows */
    self.infoWindow = new google.maps.InfoWindow({
    });

    /* show current position */
    self.putCurrentPositionMarker = function () {
        // Try HTML5 geolocation.
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                var pos = {
                    lat: position.coords.latitude,
                    lng: position.coords.longitude
                };

                self.map.setCenter(pos);

                //draw current location
                var marker = new google.maps.Marker({
                    position: new google.maps.LatLng(pos.lat, pos.lng),
                });

                marker.addListener('click', function () {
                    self.infoWindow.setContent('<div class="map-marker-info">you are here</div>');
                    self.infoWindow.open(self.map, marker);

                });

                // To add the marker to the map, call setMap();
                marker.setMap(self.map);

            }, function () {
                //handleLocationError(true, infoWindow, map.getCenter());
            });
        } else {
            // Browser doesn't support Geolocation
        }
    }


    /* show store */
    self.putStoreMarker = function (storeGroups) {
        //draw markers
        $.each(storeGroups, function (grpIdx, grp) {
            //loop group/brand
            $.each(grp.stores, function (storeIdx, store) {
                //loop store
                var marker = new google.maps.Marker({
                    position: new google.maps.LatLng(store.lat, store.lng),
                    title: store.n,
                    icon: grp.icon
                });

                //marker info
                marker.addListener('click', function () {
                    var content = '<div class="map-marker-info">' + store.n;
                    if (store.nId) {
                        content += '<a class="btn btn-primary" onclick="window.location=\'/store/' + store.nId + '\'">Select</a></div>';
                    }
                    
                    self.infoWindow.setContent(content);
                    self.infoWindow.open(self.map, marker);
                });

                // To add the marker to the map, call setMap();
                marker.setMap(self.map);
            })
        });
    }
}

function showMap() { new StoreMap($("#map")[0], STORE_MAP_MARKERS).init(); }