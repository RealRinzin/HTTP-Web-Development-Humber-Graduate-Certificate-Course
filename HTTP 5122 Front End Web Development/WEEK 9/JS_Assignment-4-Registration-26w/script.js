window.onload = init;
// Initiation of the function
function init(){
console.log("Init");

	var formHandle = document.forms.ixdForm;
    console.log(formHandle);

    formHandle.onsubmit = processForm;


    function processForm(){
        console.log("This is good");

    }

}