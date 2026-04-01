/* LAB 7 - SHIPPING FORM */
//Order Shipping object (for extra EXTRA challenge, otherwise, ignore it)
var shipInfo = {
	name: "",
	pc: "",
	speed: "",
	cost: 0
};

//==== CREATE YOUR PSEUDOCODE COMMENTS FIRST
window.onload = init;

// Start the function
function init() {

	var formHandle = document.forms.form_ship;
	// console.log(formHandle);
	formHandle.onsubmit = processForm;
	// processForm
	function processForm() {

		// Speed of delivery select box validation
		var f_speed = formHandle.f_speed;
		if (f_speed.value === "0") {
			f_speed.style.background = "red";
			return false;
		} else {
			f_speed.style.background = "white";
		}
		// First name input box validation
		var f_name = formHandle.f_Name;
		if (f_name.value === "") {
			f_name.style.border = "1px solid red";
			return false;
		} else {
			f_name.style.border = "1px solid gray";
		}
		//  Postal code input box validation
		var p_code = formHandle.f_pc;
		if (p_code.value === "") {
			p_code.style.border = "1px solid red";
			return false;
		} else {
			p_code.style.border = "1px solid gray";
		}

		// Hide the form and display the shipping information
		formHandle.style.display = "none";

		// Get Thank you message DOM
		var displayInfo = document.getElementById("thanks_msg");
		// Display the shipping information
		displayInfo.style.display = "block";
		// Customer Name
		var cName = document.getElementById("thanksCustomer");
		cName.innerHTML = f_name.value;
		// Customer Postal Code
		var cPostal = document.getElementById("thanksPC");
		cPostal.innerHTML = p_code.value;
		// Customer Speed of Delivery
		var cSpeed = document.getElementById("thanksSpeed");
		cSpeed.innerHTML = f_speed.options[f_speed.selectedIndex].text;
		// Shipping Cost
		var shippingCost = document.getElementById("thanksCost");
		shippingCost.innerHTML = f_speed.value;

		return false;
	}
	// return false;

}

//WAIT FOR THE PAGE TO LOAD


