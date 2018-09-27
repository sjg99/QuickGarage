$('.iconos .cajaadd').click(function(){  
  $('.VentanaAdd').css('top', '50%');
});
$('.edit').click(function () {
    $('.VentanaAdd').css('top', '50%');
});
$('html').click(function(){
  $('.VentanaAdd').css('top', '-50%');
});
$('.iconos .cajaadd, .VentanaAdd, .edit').click(function(e){
  e.stopPropagation();
});