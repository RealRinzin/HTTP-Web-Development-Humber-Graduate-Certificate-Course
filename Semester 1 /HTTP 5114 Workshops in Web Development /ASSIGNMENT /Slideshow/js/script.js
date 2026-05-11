var currentImg = 0;
var totalImg = 4;

function onNext() {
  currentImg++;
  if (currentImg >= totalImg) currentImg = 0;
  var el = document.getElementsByClassName(`slide`);

  for (let i = 0; i < totalImg; i++) {
    el[i].style.display = "none";
  }
  el[currentImg].style.display = "block";
}
function onPrevious() {
  currentImg--;
  if (currentImg < 0) currentImg = totalImg - 1;

  var el = document.getElementsByClassName(`slide`);

  for (let i = 0; i < totalImg; i++) {
    el[i].style.display = "none";
  }
  el[currentImg].style.display = "block";
}
