//LAB 3 - ARRAYS & LOOPS - PART 3

//PART 3 - SHOPPING CART SHIPPING
//==== VARIABLES ========
var price = [];
var threshold = 35;
var total = 0;
//==== LOGIC ========
//CHECK FOR ITEMS UNTIL THRESHOLD IS MET.
while (total < threshold) {
	var inputPrice = parseInt(prompt("Enter the Price here"));
	//GET ITEM COST FROM USER
	//CONVERT USER INPUT TO A NUMBER
	price.push(inputPrice);
	// loop
	total += inputPrice;
	//ADD ITEM COST TO RUNNING TOTAL VARIABL
	// total = inputPrice;
	//PUSH ITEM COST TO CART ARRAY
	price.push(inputPrice)
}
alert("Your shipping for this order will be free!!")
console.log("Your shipping for this order will be free!")

//SEND POPUP MESSAGE TO USER


//SEND OUTPUT TO CONSOLE

