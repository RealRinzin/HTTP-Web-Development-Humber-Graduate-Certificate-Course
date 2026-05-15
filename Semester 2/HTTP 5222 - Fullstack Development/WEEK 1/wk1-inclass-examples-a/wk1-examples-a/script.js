//TEST OLD OBJECT LITERAL SYNTAX
/* msgLogger.message = "Modified message";
msgLogger.logMessage(); */

//TEST NEWER MODULE DESIGN PATTERN
//imports with curly braces are for named imports
//import { getMessage, setMessage } from "./loggerModule.js";
//imports without curly braces are unnamed (arbitrary names) because you're importing the default exports
import logger from "./loggerModule.js";

//below is for if using the named imports
/* setMessage("New message");
getMessage(); */

//if using default import
logger.setMessage("Hello again!");
logger.getMessage();

//DEMO BLOCKING VS NON-BLOCKING SCRIPT
//The three lines below are examples of blocking code (i.e. sequential code) because line 21 blocks line 22 from executing first.
let x = 3;
let y = 18;
let sum = x + y;

let btn = document.getElementById("btn");
btn.addEventListener("click", () => {
  //This button click handler is an example of NON-BLOCKING CODE.
  //Even though this block of code comes before the sum console log, the sum displays first (i.e. it is not blocked by this event handler);
  console.log("BUTTON CLICKED!");
});

console.log(`The sum of ${x} and ${y} is ${sum}`);