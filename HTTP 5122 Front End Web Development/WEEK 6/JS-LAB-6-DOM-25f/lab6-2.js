//#### LAB 6 - DOM MANIPULATION ####
//PART 2: MYSTERY BOX

//LISTEN FOR load EVENT
window.onload = loadPage;
//'WRAPPER' FUNCTION FOR DOM LOGIC
function loadPage() {
	console.log("Loading")
	//GET DOM ELEMENTS WE'LL NEED
	var mysteryBox = document.getElementById('mysteryBox') // selection the mystery box
	var buttonBox = document.getElementById('buttonBox') // selection the button box
	var clickButton = document.getElementsByTagName("h2")[1]; // selecting the h2
	// Hover the mouseover
	mysteryBox.onmouseover = userInput;
	//====CREATE THE FUNCTIONS WE'LL NEED====
	//FUNCTION TO ASK USER
	function userInput() {
		var useSelect = confirm("Do you want to see something?")
		if (useSelect) {
			mysteryBox.style.display = 'none';
			buttonBox.style.display = 'block';
		}
	}
	// Button function click to change the 
	clickButton.onclick = buttonBoxChange;
	buttonBox.style.cursor = "pointer";
	//FUNCTION TO CHANGE buttonBox
	// Change the width, background and text of the content
	function buttonBoxChange() {
		buttonBox.style.width = "600px";
		buttonBox.style.background = "orange";
		buttonBox.innerHTML = '<h2>SURPRISE!!</h2>';

	}
}
