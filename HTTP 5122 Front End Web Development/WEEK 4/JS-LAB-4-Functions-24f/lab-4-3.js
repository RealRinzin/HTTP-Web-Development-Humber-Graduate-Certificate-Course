//#### LAB 4 - FUNCTIONS ####
//PART 3:  WALKING THE DOG 


//################## CREATE YOUR checkTemp FUNCTION
//This function will...
//It expects to receive...
//It will return...

// This function will receive user input temperature as parameter
// return condition for greater than 30 and less than -10 (return true)
// otherwise it should return false
function checkTemp(temperature) {
    if (temperature >= 30 || temperature < -10) {
        return true
    } else {
        return false
    }
}

// Receive temperature value from the User 
var currentTmp = prompt("Enter the current temperature")
// ################## LOGIC THAT OUTPUTS MESSAGES BASED ON FUNCTION RESULTS
if (checkTemp(currentTmp)) {
    // condition for temperature more than 30
    alert("Yikes! Too Hot/Cold for dog Walking!");
}
// condition between -9 to 30 temperature
else {
    alert("You're good, have a nice walk");
}
