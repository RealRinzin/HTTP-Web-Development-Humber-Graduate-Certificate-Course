function onOpen(num) {
  let element = document.getElementsByClassName("accordion-section");
  // !element[num-1].style.display?element[num-1].style.display = "block":"none";
  for (let i = 0; i < element.length; i++) {
      if (i !== num - 1) {
          element[i].style.display = "none"; 
        }
    }
  if (
    element[num - 1].style.display === "none" || element[num - 1].style.display === ""
  ) {
    // element[num -1].classList.add("animation");
    element[num - 1].style.display = "block";
  } else {
    element[num - 1].style.display = "none";
  }
  console.log(num, element[num - 1].style.display);
}
