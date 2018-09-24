function topnav() {
    var x = document.getElementById("tn");    
    if (x.className === "topnav") {
        x.className += " responsive";
        $('.SeccionHome .ContenedorHome .BotonLogin .LoginBoton2').css('display', 'none');
    } else {
        x.className = "topnav";
        $('.SeccionHome .ContenedorHome .BotonLogin .LoginBoton2').css('display', 'initial');
    }
}
$('#Home').click(function() {
    var x = document.getElementById("tn");
    x.className = "topnav";
    $('html, body').stop(true).animate({
      scrollTop: $('.SeccionHome').offset().top
    },500);
  });
  $('#About').click(function() {
    var x = document.getElementById("tn");
    x.className = "topnav";
    $('html, body').stop(true).animate({
      scrollTop: $('.SeccionAbout').position().top
    },500);
  });
  $('#Contact').click(function() {
    var x = document.getElementById("tn");
    x.className = "topnav";
    $('html, body').stop(true).animate({
      scrollTop: $('.SeccionContact').position().top
    },500);
  });
  $(window).scroll(function() {
    if($(window).scrollTop() > 200 && $('.ScrollUp').css('display') == 'none') {
      $('.ScrollUp').css('display', 'block');
      $('.ScrollUp').stop(true).animate({
        'opacity': '1'
      },300);
    } 
    else if($(window).scrollTop() <= 200 && $('.ScrollUp').css('display') == 'block'){
      $('.ScrollUp').stop(true).animate({
        'opacity': '0'
      },300);
      setTimeout(function(){
        $('.ScrollUp').css('display', 'none');
      }, 300);
    }
  });
  $('.ScrollUp').click(function() {
    $('html, body').stop(true).animate({
      scrollTop: $('.SeccionHome').offset().top
    },500);
  });
  $('#LBoton, #LBoton2').click(function() {
    var x = document.getElementById("tn");       
    x.className = "topnav";    
    $('.SeccionHome .ContenedorHome .BotonLogin .LoginBoton2').css('display', 'initial');    
    $('.SeccionHome .LoginContenedor').css('display','block');
    $('.SeccionHome .LoginContenedor').css('opacity','1');
    $('nav, .SeccionAbout, .SeccionContact, .Background, .ContenedorHome, footer').css('filter', 'blur(5px)');
  });
  $('html').click(function() { 
    setTimeout(function(){
        $('.SeccionHome .LoginContenedor').css('display','none');
    $('.SeccionHome .LoginContenedor').css('opacity','0');
    $('nav, .SeccionAbout, .SeccionContact, .Background, .ContenedorHome, footer').css('filter', 'blur(0px)');
      }, 1);          
  });
  $('#LBoton, #LBoton2').click(function(e){
    e.stopPropagation();
  });
  
 