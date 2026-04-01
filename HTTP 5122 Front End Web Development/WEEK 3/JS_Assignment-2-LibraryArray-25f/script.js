'use strict'
// var myTopMovies = ['Pursuit of Happiness','Life is Beautiful','Forrest Gump','Seven Years in Tibet'];
// declare and initialize 7 variables with 7 movie names.
var movie1 = "Pursuit of Happiness";
var movie2 = "Life is Beautiful";
var movie3 = "Seven Years in Tibet";
var movie4 = "Forrest Gump";
var movie5 = "Iron Man";
var movie6 = "3 Idiots";
var movie7 = "My mother";

// create a JavaScript array to hold these variables and 
// represent your top 7 movie list
var myTopMovies = [movie1, movie2, movie3,movie4,movie5,movie6,movie7];
// Create a true or false situation for the valid vs invalid user input
var valid = true;
// Do the while condition the check if the user has input a proper value
// keep fall back to the prompt through while loop unless 
// the user has entered a valid number between 1-7
while (valid) {
    // "Which top 7 movie would you like?" 5. The default text will read, "Pick a number: 1-7"
    // Input Prompt from the user
    var userChoice = prompt("Which top 7 movie would you like?");
    // Convert the user input to number
    var userChoiceNumber = parseInt(userChoice);
    // Check the conditions
    // Check the NaN and value between 1-7 
    if (!isNaN(userChoiceNumber)&& Number.isInteger(userChoiceNumber) && (userChoiceNumber > 0 && userChoiceNumber <= 7)) {
        // Display the response message
        // alert(`Movie ${userChoiceNumber}: ${myTopMovies[userChoiceNumber - 1]}`)
        alert(`Number ${userChoiceNumber} on the list is : ${myTopMovies[userChoiceNumber - 1]}` )
        // Display all the movie lists
        console.log("The list of all the top 7 Movies:")
        // Loop through all the movies list and console log it
        for (var i = 0; i < myTopMovies.length; i++) {
            console.log(`Movie ${i+1}: ${myTopMovies[i]}`)
        }
        // End the While Loop here
        valid = false;

    }else{
        alert("Please enter between # 1 - 7 !")
    }

}
