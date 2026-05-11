//######## LAB 2-3 EMAIL SIGNUP ########
// alert("hey 2.3");//COMMENT OUT ONCE CONNECTED TO YOUR HTML PAGE
//==== VARIABLES =========
var mail='me@example.com'
var subConfirmation = confirm("Would you like to jon mailing list")
// Logic If the condition is TRUE
if(subConfirmation===true){
    var email = prompt("Enter your email address here", mail);
    if(email !==null && email===mail && email!==""){
        alert("Thank you, our next newsletter will be "+email)
    }else{
        alert("Thank you, but your email was not valid")
    }
}else{
    alert("Thank you, we will not bother you again.")
}
// Logic for - if the condition is FALSE

//==== LOGIC =============