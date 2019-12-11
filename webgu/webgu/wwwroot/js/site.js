// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
var button = document.getElementById("buttonsubmit");

function showFlights() {
    window.location.href("showflights.cshtml");
}
window.onlick = showFlights;