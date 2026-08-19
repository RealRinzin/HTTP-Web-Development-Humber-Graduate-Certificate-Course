console.log("JS is working")

// Team Member Ararry
var teamMembers = [
    { 'id': 1, 'first_name': "Mike", "last_name": "Miller" },
    { 'id': 2, 'first_name': "Larry", "last_name": "Page" },
    { 'id': 3, 'first_name': "Diana", "last_name": "Musk" },
    { 'id': 4, 'first_name': "Sam", "last_name": "Mike" },
    { 'id': 5, 'first_name': "Adams", "last_name": "Jack" },
    { 'id': 6, 'first_name': "Rinzin", "last_name": "Tenzin" },
]

// Problem sets
// User will receive input team member ID options
const teamNumberInput = parseInt(prompt("Which Team do you belong to", "eg. 1 or 2 .."));

// but if user enter the correct id [1,...6]
if (typeof (teamNumberInput) === 'number' && teamNumberInput >= 1 && teamNumberInput <= 6) {
    // If user enter text or null or team id that are not exist
    // it should block the further access and tell the user access denied
    // the user will receive another input popup to enter the first name 
    const first_name = prompt("Enter the first Name").trim();
    // Once they enter the name, program is going the check if the first name exist in the list of team member names
    // Find matching team member by name only
    const matchedMember = teamMembers.find(member =>
        member.first_name.toLowerCase() === first_name.toLowerCase()
    );
    // Check the match
    if (matchedMember) {
        alert(`Welcome ${matchedMember.first_name} ${matchedMember.last_name}, Good afternoon`);
    } else {
        alert("You are access denied.... please choose correct option");
    }
    // if user enter wrong first name, it will block the access
} else {
    alert("You are access denied.... please choose correct option")
}








