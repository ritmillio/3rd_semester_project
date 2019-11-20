let roundtrip;
let passangers;
let ec_bus;
let from;
let to;
let button;

roundtrip = document.getElementById("dropdownlist1");
passangers = document.getElementById("dropdownlist2");
ec_bus = document.getElementById("dropdownlist3");
from = document.getElementById("fromsearchinput");
to = document.getElementById("tosearchinput")
button = document.getElementById("searchbutton");

let roundtripStrUser = roundtrip.options[roundtrip.selectIndex].value;
let passangersStrUser = passangers.options[passangers.selectIndex].value;
let ec_busStrUser = ec_bus.options[ec_bus.selectIndex].value;
let fromStrUser = from.options[from.selectIndex].value;
let toStrUser = to.options[to.selectIndex].value;


button.addEventListener("click" , window.location.href = "seatreservation.html");

function validationForm() {
    /*
        function validateForm() {
    var x = document.forms["myForm"]["fname"].value;
    if (x == "") {
        alert("Name must be filled out");
        return false;
    }
        }
    */
}
function navigateNewPage(){
    button.addEventListener("click" , window.location.href = "seatreservation.html");
}