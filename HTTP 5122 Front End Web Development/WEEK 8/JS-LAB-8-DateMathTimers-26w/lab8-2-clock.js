/* LAB 8.2 - STOP TIME */


//create page load listener
window.onload = init;
//create page load function
function init() {
	console.log("Loading")
	//create variables for required HTML elements
	var hour = document.getElementById("hoursOut")
	var minute = document.getElementById("minsOut")
	var second = document.getElementById("secsOut")
	var startBtn = document.getElementById("btnStart")
	var stopBtn = document.getElementById("btnStop")
	
	var timer;
	function displayTime() {
		var currentDate = new Date();
		console.log(currentDate.getSeconds())
		hour.innerHTML = currentDate.getHours();
		minute.innerHTML = `:${belowTen(currentDate.getMinutes())}`;
		second.innerHTML = `:${belowTen(currentDate.getSeconds())}`;
	}
	//CREATE FUNCTION TO START THE CLOCK.
	function startTime() {
		timer = setInterval(displayTime,1000)
	}
	//CREATE FUNCTION TO STOP THE CLOCK
	function stopTime() {
		clearInterval(timer)
	}
	// SET EVENT LISTENERS
	// Check the valueZero
	function belowTen(value) {
		if (value < 10) {
			return `0${value}`
		} else {
			return value;
		}
	}
	//create time variable so all functions have access to it
	startBtn.onclick = startTime;
	stopBtn.onclick = stopTime;

}