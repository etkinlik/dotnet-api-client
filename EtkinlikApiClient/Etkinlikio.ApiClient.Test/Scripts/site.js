var i = 0;
function hideShow() {
    if (++i % 2 == 0) {
        document.getElementById('formFiltre').style.display = "none";
    } else {
        document.getElementById('formFiltre').style.display = "block";
    }
}
