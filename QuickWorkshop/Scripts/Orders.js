function topnav() {
    var x = document.getElementById("ib");
    if (x.className === "infoBar") {
        x.className += " responsive";
    } else {
        x.className = "infoBar";
    }
}
