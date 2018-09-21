/////////////////////////Variables de Control/////////////////////////
var NavAbierto = false;
var LoginAbierto = false;
var EsCelGen = false;
var MinHeight = window.innerHeight;
/////////////////////////Variables de Nav/////////////////////////
var MarginContHome = $('.SeccionHome .ContenedorHome').css('padding-top');
var MarginLi = "10px 15px 10px 15px";
var PadingLi = "5px 35px 5px 35px";
var FontLi = "14px";
var HeightLi = "auto";
/////////////////////////Variables de Responsive/////////////////////////
var ScrollUp1 = $('.ScrollUp').css('width');
//****************Nav bar****************//
var nav1 = $('nav').css('position');
var nav2 = $('nav').css('background-color');
var dropicon1 = $('nav .dropicon').css('display');
var dropicon2 = $('nav .dropicon').css('float');
var dropicon3 = $('nav .dropicon').css('color');
var dropicon4 = $('nav .dropicon').css('font-size');
var Topnav1 = $('nav .Topnav').css('float');
var Topnav2 = $('nav .Topnav').css('width');
var Topli1 = $('.Topnav li').css('display');
var Topli2 = $('.Topnav li').css('margin-bottom');
var Topli3 = $('.Topnav li').css('margin-top');
var Toplia1 = $('nav .Topnav li a').css('text-align');
var Toplia2 = $('nav .Topnav li a').css('color');
var Toplia3 = $('nav .Topnav li a').css('font-size');
var Toplia4 = $('nav .Topnav li a').css('margin');
var Toplia5 = $('nav .Topnav li a').css('padding');
var Toplia6 = $('nav .Topnav li a').css('height');
var droplogo1 = $('nav .dropLogo').css('width');
var droplogo2 = $('nav .dropLogo').css('height');
var LoginBotonP = $('nav .Topnav li .LoginBoton').css('padding');
var LoginBotonH = $('nav .Topnav li .LoginBoton').css('height');
//****************Home****************//
var Logo = $('nav .dropLogo').css('background-image');
var TextoPrincipal = $('.SeccionHome .ContenedorHome .TextoPrincipal').css('font-size');
var LoginBoton2 = $('.SeccionHome .ContenedorHome .BotonLogin .LoginBoton2').css('font-size');
var LoginBoton2P = $('nav .Topnav li .LoginBoton').css('padding');
//****************Login y Singup****************//
var LoSi = $('.SeccionHome .LoSiContenedor .Login, .SeccionHome .LoSiContenedor .SingUp').css('width');
var LoSiFontRe = $('.SeccionHome .LoSiContenedor .Login form .ContFormLogin .ResultadoLogin, .SeccionHome .LoSiContenedor .SingUp form .ContFormSingup .ResultadoSingup').css('font-size');
var LoSiFont = $('.SeccionHome .LoSiContenedor .Login form .ContFormLogin .LoginCampos input, .SeccionHome .LoSiContenedor .SingUp form .ContFormSingup .SingupCampos input').css('font-size');
var LoSiFontBut = $('.SeccionHome .LoSiContenedor .Login form .ContFormLogin .LoginBotones buttom, .SeccionHome .LoSiContenedor .SingUp form .ContFormSingup .SingupBotones buttom').css('font-size');
var LoSiMarginLab = $('.SeccionHome .LoSiContenedor .Login form .ContFormLogin .LoginCampos input, .SeccionHome .LoSiContenedor .SingUp form .ContFormSingup .SingupCampos input').css('margin');
var LoSiPaddingBut = $('.SeccionHome .LoSiContenedor .Login form .ContFormLogin .LoginBotones buttom, .SeccionHome .LoSiContenedor .SingUp form .ContFormSingup .SingupBotones buttom').css('padding');
var LoSiLabFont = $('.SeccionHome .LoSiContenedor .lbl').css('font-size');
//****************Contact****************//
/****************About****************/
var ContenedorFila = $('.SeccionAbout .ContenedorAbout .Fila').css('flex-direction');
var ContenedorColumna = $('.SeccionAbout .ContenedorAbout .Fila .Columna').css('width');
var ParrafoAbout = $('.SeccionAbout .ContenedorAbout .Fila .Columna .box .ParrafoAbout, .SeccionAbout .ContenedorAbout .Fila .Columna .box .LearnMore').css('font-size');
var AboutIconos1 = $('.SeccionAbout .ContenedorAbout .Fila .Columna .box .ContIconos .IconosExtremos').css('width');
var AboutIconos2 = $('.SeccionAbout .ContenedorAbout .Fila .Columna .box .ContIconos .IconoMedio').css('width');
/////////////////////////Nav/////////////////////////
$('nav .dropLogo,nav .dropicon').click(function() {
  if($('nav .Topnav li:not(:nth-child(5)').css('display') == "none" || $('nav .Topnav li:not(:nth-child(5)').css('display') == "inline"){
    AbreNav();
  }
});
$('section').click(function() {
  if(NavAbierto == true){
    AbreNav();
  }
});
function AbreNav(){
  if(NavAbierto == false) {
    $('nav .Topnav li a, nav .Topnav li .LoginBoton').css({
      "margin": MarginLi,
      "font-size": FontLi,
      "height": HeightLi
    });
    $('nav .Topnav li .LoginBoton').css('padding', PadingLi);
    $('.SeccionHome .ContenedorHome .BotonLogin .LoginBoton2').css('opacity', '0');
    $('.SeccionHome .ContenedorHome .BotonLogin .LoginBoton2').css('visibility', 'hidden');
    $('.SeccionHome .ContenedorHome').stop(true).animate({
        "padding-top":"25%"
    },270);
    NavAbierto = true;
  }
  else {
    $('nav .Topnav li a, nav .Topnav li .LoginBoton').css({
      "margin": "0",
      "padding": "0",
      "font-size": "0",
      "height": "0"
    });
    $('.SeccionHome .ContenedorHome .BotonLogin .LoginBoton2').css('visibility', 'visible');
    $('.SeccionHome .ContenedorHome .BotonLogin .LoginBoton2').css('opacity', '1');
    $('.SeccionHome .ContenedorHome').stop(true).animate({
        "padding-top":MarginContHome
    },270);
    NavAbierto = false;
  }
}
/////////////////////////Smooth Scroll/////////////////////////
$('#Home').click(function() {
  if(NavAbierto == true){
    AbreNav();
  }
  $('html, body').stop(true).animate({
    scrollTop: $('.SeccionHome').offset().top
  },500);
});
$('#About').click(function() {
  if(NavAbierto == true){
    AbreNav();
  }
  $('html, body').stop(true).animate({
    scrollTop: $('.SeccionAbout').position().top
  },500);
});
$('#Contact').click(function() {
  if(NavAbierto == true){
    AbreNav();
  }
  $('html, body').stop(true).animate({
    scrollTop: $('.SeccionContact').position().top
  },500);
});
$('#Login').click(function() {
  if(NavAbierto == true){
    AbreNav();
  }
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
/////////////////////////Login y SingUp/////////////////////////
$('.SeccionHome .ContenedorHome .BotonLogin .LoginBoton2, nav .Topnav li .LoginBoton').click(function(){
  $('.SeccionHome .LoSiContenedor').css('display', 'flex');
  $('.SeccionHome .LoSiContenedor').stop(true).animate({
    'opacity': '1'
  },300);
  if(EsCelGen == false){
    $('nav, .ScrollUp, .ContenedorAbout, .ContenedorContact, .ContenedorHome, .SeccionHome .Background, .SeccionHome .ContenedorHome').css('filter', 'blur(2px)');
  }
});
$('html').click(function(){
  $('.SeccionHome .LoSiContenedor').stop(true).animate({
    'opacity': '0'
  },300);
  setTimeout(function(){
    $('.SeccionHome .LoSiContenedor').css('display', 'none');
    $('.SeccionHome .LoSiContenedor .Login').css('transform', 'scaleX(1) translate(-50%,-50%)');
    $('.SeccionHome .LoSiContenedor .SingUp').css('transform', 'scaleX(0) translate(-50%,-50%)');
  }, 300);
  if(EsCelGen == false){
    $('nav, .ScrollUp, .ContenedorAbout, .ContenedorContact, .ContenedorHome, .SeccionHome .Background, .SeccionHome .ContenedorHome').css('filter', 'blur(0px)');
  }
});
$('.SeccionHome .ContenedorHome .BotonLogin .LoginBoton2, nav .Topnav li .LoginBoton, .SeccionHome .LoSiContenedor .Login, .SeccionHome .LoSiContenedor .SingUp').click(function(e){
  e.stopPropagation();
});
$('.SeccionHome .LoSiContenedor .Login form .ContFormLogin .LoginBotones .SingUpBotton').click(function(){
  $('.SeccionHome .LoSiContenedor .Login').css('transform', 'scaleX(0) translate(-50%,-50%)');
  setTimeout(function(){
    $('.SeccionHome .LoSiContenedor .SingUp').css('transform', 'scaleX(1) translate(-50%,-50%)');
  }, 300);
});
$('.SeccionHome .LoSiContenedor .SingUp form .ContFormSingup .SingupBotones .CancelBotton').click(function(){
  $('.SeccionHome .LoSiContenedor .SingUp').css('transform', 'scaleX(0) translate(-50%,-50%)');
  setTimeout(function(){
    $('.SeccionHome .LoSiContenedor .Login').css('transform', 'scaleX(1) translate(-50%,-50%)');
  }, 300);
});