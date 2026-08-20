//#### LAB 4 - FUNCTIONS ####
//PART 2:  AN AVERAGE FUNCTION


var webDesign = 80;
var interactiveDesign = 90;
var frontEndDevelopment = 90;
var backEndDevelopment = 20;
var introductionWeb = 89;

//################## CREATE YOUR AVERAGE FUNCTION
//This function takes five numbers and returns their average to one decimal place.
function avgFiveNumber(course1, course2, course3, course4, course5) {
    return ((course1 + course2 + course3 + course4 + course5) / 5).toFixed(1)   
}
//################## LOGIC THAT OUTPUTS MESSAGES BASED ON FUNCTION RESULTS
// var result = avgFiveNumber(webDesign,interactiveDesign,frontEndDevelopment,backEndDevelopment,introductionWeb);
if (avgFiveNumber(webDesign, interactiveDesign, frontEndDevelopment, backEndDevelopment, introductionWeb) >= 70) {
    alert("You have passed the course")
} else {
    alert("Review required")
}

