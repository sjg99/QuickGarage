function myMap()
{
  myCenter=new google.maps.LatLng(4.666624, -74.101608);
  var mapOptions= {
    center:myCenter,
    zoom:15, scrollwheel: false, draggable: false,
    mapTypeId:google.maps.MapTypeId.ROADMAP
  };
  var map=new google.maps.Map(document.getElementById("googleMap"),mapOptions);

  var marker = new google.maps.Marker({
    position: myCenter,
  });
  marker.setMap(map);
}