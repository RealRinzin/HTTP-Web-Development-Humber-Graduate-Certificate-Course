// Private arrays
var fruits = ['Apple','Orange','Banana','Pine Apple'];

// Add New Element at the end of the existing array (Fruits)
export function addNewElement(newItem){
    fruits.push(newItem)
    console.log(fruits)
}

// Return Last element from array Function
export function getLastElement(){
    const lastItem = fruits[fruits.length -1 ];  
    console.log(lastItem)
}