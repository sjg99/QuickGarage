$('.iconos .cajaadd, .edit').click(function(){  
  $('.VentanaAdd').css('display', 'flex');
  $('nav, .infoBar, .contenedor-padre').css('filter', 'blur(2px)'); 
});
$('html').click(function(){
  $('.VentanaAdd').css('display', 'none');
  $('nav, .infoBar, .contenedor-padre').css('filter', 'blur(0px)');  
});
$('.iconos .cajaadd, .VentanaAdd, .edit').click(function(e){
  e.stopPropagation();
});