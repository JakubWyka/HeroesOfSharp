function produce()
{
    var xmlhttp = new XMLHttpRequest();
    xmlhttp.open("GET", "/Home/Produce", true);
    xmlhttp.send();
}

produce();
setInterval(function () { produce() }, 5*1000);
