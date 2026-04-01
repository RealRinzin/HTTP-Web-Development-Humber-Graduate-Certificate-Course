var currentSlide = 0;
var slideImages = document.getElementById('slideshow')
const slides = slideshow.getElementsByClassName("slide");

var total = slideImages.childElementCount;


// Previous
function pre() {

    if (currentSlide === 0) return;

    for (let i = 0; i < total; i++) {
        slides[i].style.display = "none";
    }
    slides[currentSlide].style.display = "block";
    currentSlide = currentSlide - 1;

}
// Next;
function next() {
    if (currentSlide === total-1) return;

    for (let i = 0; i < total; i++) {
        slides[i].style.display = "none";
    }
    slides[currentSlide].style.display = "block";
    currentSlide = currentSlide + 1;
}



