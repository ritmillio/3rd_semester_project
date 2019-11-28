var departureLocation = document.getElementById("departurelocation");
var arrivalLocation = document.getElementById("");
var checkIn = document.getElementById("");
var checkOut = document.getElementById("");
var trip = document.getElementById("");
var passenger = {
    passenger = document.getElementById("").value
};
var economyOrBusiness = document.getElementById("").value;
var button = document.getElementById("buttonsubmit");

function search(){
    if(departureLocation.value == "Aalborg" && arrivalLocation.value == "Copenhagen"){
        window.location.pathname = "..Web/airbus380.html/";
    }else{

    }
}
$(function calendar() {
    $("#datepicker").datepicker();
});
