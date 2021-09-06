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
    var results = [0, 1, 2]
            .sort(function() { return .5 - Math.random() }) // Shuffle array
            .slice(0, 2); // Get first 2 items
    console.log(results);
    incorrects[results[0]].children[0].disabled = true;
    incorrects[results[1]].children[0].disabled = true;
    console.log(incorrects);
    incorrects[results[0]].setAttribute("class", "hidden");
    console.log(incorrects);
    incorrects[results[1]].setAttribute("class", "hidden");
}