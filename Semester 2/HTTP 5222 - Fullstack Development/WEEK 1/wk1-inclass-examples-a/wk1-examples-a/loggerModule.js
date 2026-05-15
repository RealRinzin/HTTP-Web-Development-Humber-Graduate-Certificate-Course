//MODULE EXAMPLE
//The logger is for logging messages to the console.
//The message property below is private because I'm not exporting it.
var message = "My hidden message";

//The getMessage() function is public because it's exported.
export function getMessage() {
  console.log(message);
}

export function setMessage(newMsg) {
  message = newMsg;
}

let object = {
  getMessage,
  setMessage
};

//There can only be ONE default export per module file.
export default {
  getMessage,
  setMessage
};