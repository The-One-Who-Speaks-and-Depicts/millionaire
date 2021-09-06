// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function getRandomInt(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min)) + min; 
}

var fifty_used = document.getElementById("Yes");
var fifty_being_used = document.getElementById("Now");
if (fifty_used !== null) {
    fifty_used.disabled = true;
}
if (fifty_being_used !== null) {
    fifty_being_used.disabled = true;
    const incorrects = document.getElementsByClassName("False");
    let first = getRandomInt(0, incorrects.length);
    incorrects[first].children[0].disabled = true;
    incorrects[first].setAttribute("class", "hidden");
    let second = getRandomInt(0, incorrects.length);
    incorrects[second].children[0].disabled = true;
    incorrects[second].setAttribute("class", "hidden");
}