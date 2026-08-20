## Naming Conventions
const visible -> isVisible = true |false
const activities -> hasActivities = true | false

Scope
### Global scope
```js
const clientName ="Rinzin";
function getUserName(){
console.log(clientName)
}
```

### Function scope
```js
function getUserName(){
const clientName ="Rinzin";
}
console.log(clientName) // Error here because its out of scope 
```
### Block scope
```js
if(true){
const clientName ="Rinzin";
}
console.log(clientName) // Error here because its out of scope 

```

## Classes

```js
class Developer{
    name;
    income;
    constructor(nameIn){
        this.name = nameIn
    }
}

const webDev = new Developer("Rinzin");
```
## JS Events
```js
<button id="change_color">Change Color</button>
const colorButton = document.getElementById("change_color");
colorButton.addEventListener('click',()=>{
    console.log("clicked")
})

```
## Forms
```js
const locationForm = document.forms.location_form
// onclick
locationForm.onsubmit = submitFormHandler;
// function
function submitFormHandler(){
    console.log("form")
}
```

## textContent vs innerHTML
```js
<p id="list"></p>
const text = document.getElementById("list")
locationData.textContent = "This is list"; // <p> This is list </p>

locationData.innerHTML = "<span>This is adding span  inside</span>"; // <p> This is list </p> 

