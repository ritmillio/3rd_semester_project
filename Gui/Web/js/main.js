var departureLocation = document.getElementById("departurelocation");
var arrivalLocation = document.getElementById("arrivallocation");
var searchButton = document.getElementsByClassName("submit-btn");

function myFunc(){
    if (departureLocation == 'Aalborg' ) {
        alert("HelloWorld");
    }else{
        alert("Something went wrong");
    }
}
setTimeout(myFunc , 5000);
console.log(departureLocation.innerHTML("Aalborg"));