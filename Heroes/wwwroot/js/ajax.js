function produce() {
    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            document.getElementById("resources").innerHTML = this.responseText;
        }
    };
    xmlhttp.open("GET", "/Home/Produce", true);
    xmlhttp.send();
}

function amIAttacked() {
    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200 && this.responseText !== "") {
            location.href = "/Home/Fight";
        }
    };
    xmlhttp.open("GET", "/Home/AmIAttacked", true);
    xmlhttp.send();
}

function fightInfo() {
    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            document.getElementById("async").innerHTML = this.responseText;
        }
    };
    xmlhttp.open("GET", "/Home/FightInfo", true);
    xmlhttp.send();
}

function asyncRequests()
{
    produce();
    if (window.location.pathname !== "/Home/Fight") {
        amIAttacked();
    }
    else {
        fightInfo();      
    }
}

asyncRequests();
setInterval(function () {
    asyncRequests();
}, 15 * 1000);
