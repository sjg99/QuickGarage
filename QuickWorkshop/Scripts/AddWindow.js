$('.iconos .cajaadd, .edit, .izq .icono').click(function(){  
  $('.Ventana').css('display', 'block');
  $('nav, .infoBar, .contenedor-padre').css('filter', 'blur(2px)');
  var x = document.getElementById("ib"); 
  x.className = "infoBar"; 
});
$('html').click(function(){
  $('.Ventana').css('display', 'none');
  $('nav, .infoBar, .contenedor-padre').css('filter', 'blur(0px)');  
});
$('.iconos .cajaadd, .VentanaAdd, .edit, .izq .icono').click(function(e){
  e.stopPropagation();
});
function topnav() {
  var x = document.getElementById("ib");    
  if (x.className === "infoBar") {
      x.className += " responsive";         
  } else {
      x.className = "infoBar";              
  }
}