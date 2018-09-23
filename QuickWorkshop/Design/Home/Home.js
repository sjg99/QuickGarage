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