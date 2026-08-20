import { addNewElement, getLastElement } from "./module.js";
// Add new Fruit in
addNewElement('Papaya')
// Get the last Fruit from the array
getLastElement();
// ------------------- Blocking -----------------------
console.log("Starting point")
for (var i = 0; i < 10; i++) {
    var sum = i+1
    console.log(sum)
}

// The line below is blocked till the for loop is completed run till 100
console.log("Blocked till the loop is executed fully")
const a = 4;
const b = 5;
const total = a +b;
console.log(total)

console.log("This is not blocked by the above non blocked section")

