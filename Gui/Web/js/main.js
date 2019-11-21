
/*jquery load test
if (typeof jQuery == 'undefined') {
    console.log("good");
}
else{
    console.log("Somethings wrong");
}
--> jquery loaded */
let button;
let from;
let to;

button = document.getElementById("searchbutton");
from = document.getElementById("fromsearchinput");
to = document.getElementById("tosearchinput");

function search(){
    window.location("seatreservation.html");
}


