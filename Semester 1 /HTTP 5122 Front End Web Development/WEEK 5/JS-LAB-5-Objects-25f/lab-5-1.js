//#### LAB 5 - FUNCTIONS & OBJECTS ####
//PART 1:  I OBJECT!
var meObject = {
    name:'Rinzin',
    studentID:'H343001',
    college:'Humber North',
    course :' Web  Development',
    // Methods 
    detail:function(){
        alert(`My name is ${meObject.name} and I am studying ${meObject.course} at ${meObject.college}`)
    }
}
// Accessing the detail
meObject.detail();