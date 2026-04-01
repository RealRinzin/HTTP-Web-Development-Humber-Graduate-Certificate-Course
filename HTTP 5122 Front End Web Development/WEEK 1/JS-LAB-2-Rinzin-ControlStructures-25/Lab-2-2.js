//######## LAB 2-2 LOGIN ########
//1. LINK THIS JS FILE TO THE HTML FILE
// alert("hey 2.2");//COMMENT OUT ONCE CONNECTED TO YOUR HTML PAGE

//====VARIABLES===============
//2. CREATE NECESSARY VARIABLES
		// Correct user name
		// Correct password
		// user name input
		// password input
var username = "dart";
var password ="vader";
//====LOGIC===================
//3. CREATE POPUP BOX FOR USERNAME
var usernameConfirmation = prompt("Enter Username")
//4. OUTPUT PROVIDED USERNAME TO JS CONSOLE
console.log("username",usernameConfirmation)
//5. CREATE POPUP BOX FOR PASSWORD
var passwordConfirmation = prompt("Enter Password")
//6. OUTPUT PROVIDED PASSWORD TO JS CONSOLE
console.log("password",passwordConfirmation)

//7. CHECK IF PROVIDED USERNAME AND PROVIDED PASSWORD MATCH THE STORED USERNAME/PASSWORD
if(usernameConfirmation===username && passwordConfirmation === password){
	alert("Welcome back" +username)
	console.log("Login successful")
}else{
	alert("Invalid username / password")
	console.log("Login Failed")
}
//8. IF THEY MATCH, POPUP SUCCESS MESSAGE AND OUTPUT TO CONSOLE



//9. IF THEY DON'T MATCH, POPUP INVALID MESSAGE & OUTPUT TO CONSOLE