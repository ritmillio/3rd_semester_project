var departureLocation = document.getElementById("departurelocation").value;
var arrivalLocation = document.getElementById("arrivallocation").value;
var button = document.getElementById("buttonsubmit");

button.onclick = function search(){};

function search(){
    if(departureLocation == "Aalbrog" && arrivalLocation == "Copenhagen"){
        window.location.href("seatreservation.html");
        alert("Working");
    }else{
        alert("Cant find");
    }
}

