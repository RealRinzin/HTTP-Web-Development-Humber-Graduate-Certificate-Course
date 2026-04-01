
/**
 * 
 * @init
 * Window load on browser
 */
window.onload = init;
/**
 * 
 * @init
 * 
 */
// Load the Init Function
function init() {
  var formHandle = document.forms.ixdForm;
  formHandle.onsubmit = formSubmit;

}
/**
 * 
 * @function
 * Form Submit Click Function
 * Check all the validations inside this function 
 */
function formSubmit() {
  // validate the form field before submitting it 
  if (!validateFormField()) {
    return false;
  }
  // Result View
  resultView();
  // Change th UI
  changeView();
  // Prevent default
  return false;

}

/**
 * 
 * @function 
 * In this function
 * we will be validating all the fields
 * such as First Name, Last Name, Humber ID
 * Humber Program  and Project Selection
 */
function validateFormField() {

  // Clear the background color to default
  function clearError(el) {
    el.style.backgroundColor = "";
  }
  // Set the background field red if the input is not valid
  function setError(el) {
    el.style.backgroundColor = '#ff4060';
    el.focus();
  }
  // Form First Name field
  var first_name = document.getElementById("in_fName");
  clearError(first_name);
  if (first_name.value.trim() === "") {
    setError(first_name);
    return false;
  }
  // Form Last Name field
  var last_name = document.getElementById("in_lName");
  clearError(last_name);
  if (last_name.value.trim() === "") {
    setError(last_name);
    return false;
  }
  // Form Humber ID field

  var humberId = document.getElementById("in_id");
  clearError(humberId);
  var regex = /^[Nn]\d{8}$/;
  if (!regex.test(humberId.value.trim())) {
    setError(humberId);
    return false;
  }
  // Form Humber Program
  var humber_program = document.getElementById("in_program");
  clearError(humber_program);
  if (humber_program.value === "X") {
    setError(humber_program);
    return false;
  }
// captions
  var title = document.getElementById("caption_project");
  title.style.backgroundColor = "";
  var radios = document.forms["ixdForm"]["f__project"];
  var projectChosen = false;
  for (var i = 0; i < radios.length; i++) {
    if (radios[i].checked) {
      projectChosen = true;
      break;
    }
  }
  if (!projectChosen) {
    title.style.backgroundColor = "#ff4060";
    return false;
  }

  // only return valid
  return true;
}

/**
 * 
 * @function
 * view Result
 */

function resultView() {
  // First Name
  var first_name = document.getElementById("in_fName").value.trim();
  document.getElementById("result__Fname").textContent = first_name;

  // Last Name
  var last_name = document.getElementById("in_lName").value.trim();
  document.getElementById("result__Lname").textContent = last_name;

  // Humber ID
  var humberId = document.getElementById("in_id").value.trim();
  document.getElementById("result__id").textContent = humberId;

  // Program 
  var programSelect = document.getElementById("in_program");
  var fullProgramName = programSelect.options[programSelect.selectedIndex].text;
  document.getElementById("result__program").textContent = fullProgramName;

  // program Choice
  var radios = document.forms["ixdForm"]["f__project"];
  var chosenProject = "";
  for (var i = 0; i < radios.length; i++) {
    if (radios[i].checked) {
      chosenProject = radios[i].value;
      break;
    }
  }
  document.getElementById("result__project").textContent = chosenProject;

}

/**
 * 
 * @function
 * Change the view of the ui. 
 * Only display the validated form details
 */
function changeView() {
  document.getElementById("welcome").style.display = "none";
  document.getElementById("form").style.display = "none";
  document.getElementById("result").style.display = "block";

}
