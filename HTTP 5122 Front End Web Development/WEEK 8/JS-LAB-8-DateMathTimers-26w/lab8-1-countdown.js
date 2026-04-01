/* LAB 8-1 - FINAL COUNTDOWN!! */
//create page load listener
window.onload = init;
//create page load function
function init() {
	console.log("Init page")
	//create variables for required HTML elements
	var todayDate = document.getElementById("todayData");
	var finalDate = document.getElementById("finalData");
	var dueDate = document.getElementById("dueData")
	var lateSubmission = document.getElementById('countMsg')
	//create variables for now date and due date
	var currentDate = new Date();
	var lastDate = new Date("April 24, 2023 18:00:00");
	//OUTPUT NOW DATE & DUE DATE TO HTML PAGE
	todayDate.innerHTML = currentDate.toDateString();
	finalDate.innerHTML = lastDate.toDateString();

	//CONVERT TO UTC AND SUBTRACT TO GET TIME DIFFERENCE
	var daysLeft = Math.floor((lastDate.getTime() - currentDate.getTime()) / 86400000)
	//CONVERT TIME DIFFERENCE TO WHOLE NUMBER OF DAYS
	//LOGIC TO CHECK IF DUE DATE HAS PASSED, AND OUPUT APPROPRIATE MESSAGE TO HTML PAGE
	if(currentDate.getTime() < lastDate.getTime()){
		// console.log("Still submit")
		dueDate.innerHTML = daysLeft;
	}else{
		lateSubmission.innerHTML = 'The Deadline for the final Assignment has passed!';
	}
}
