function produce()
{
    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("resources").innerHTML = this.responseText;
        }
    };
    xmlhttp.open("GET", "/Home/Produce", true);
    xmlhttp.send();
}

produce();
setInterval(function () { produce() }, 5*1000);
