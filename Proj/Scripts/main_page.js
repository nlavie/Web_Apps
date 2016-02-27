var init_map = function (id, lat, long) {
    var myLocationAddress 
    var myLocation = new google.maps.LatLng(lat, long);
    var mapOptions = {
        center: myLocation,
        zoom: 16
    };
   var marker = new google.maps.Marker({
        position: myLocation,
        title: "Store Location"
    });
    var map = new google.maps.Map(document.getElementById(id),
        mapOptions);
    marker.setMap(map);
}


