function openAccordion(accordionNumber) {
    // 
    let section = document.getElementsByClassName('accordion-section')
    for (var i = 0; i < section.length; i++) {
        section[i].style.display = "none"
    }
    console.log(section[accordionNumber - 1].style.display)
    if (section[accordionNumber - 1].style.display === 'inline') {
        section[accordionNumber - 1].style.display = "none";
    } else {
        section[accordionNumber - 1].style.display = "inline";
    }
    // Collapse 

}
// document.getElementById()
console.log("Js file")