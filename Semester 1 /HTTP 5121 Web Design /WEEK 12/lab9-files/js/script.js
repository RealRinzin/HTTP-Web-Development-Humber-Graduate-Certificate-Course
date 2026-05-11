//buttons
let start = document.getElementById("start");
let stop = document.getElementById("stop");

//animated elements
let egg = document.getElementById("egg");
let yolk = document.getElementById("yolk");

let intervalId; //to be used with setInterval to cancel with clearInterval

let duration = 40; /* In seconds, this should be same duration as the animation */
let timeElapsed = 0; //to be updated with setInterval

start.addEventListener("click", () => {
  //TODO: set status message to "Cooking"
  
  //TODO: disable "Cook" button by setting "disabled" property
    
  //TODO: start all animations running
  
  //if intervalId is not defined, add setInterval to refresh timer display every second
  if (!intervalId) {
    //TODO: add setInterval and set value of intervalId
    //https://developer.mozilla.org/en-US/docs/Web/API/Window/setInterval#examples 
  //{ start setInterval
    
      //Inside interval: increment timeElapsed
    
      //Inside interval: if time has reached duration, cancel interval and stop animations with stopTimer()
      
      //Inside interval: Display time elapsed in seconds in .timer span
      
  //} end of setInterval
  }
});
stop.addEventListener("click", () => {
  //TODO: stop timer and animations using stopTimer()
  
});

//TODO: Function to stop the timer and all animations
function stopTimer() {
  //Clear interval
  
  //Pause all animations
  
  /*
    Change status message to display whether or not egg cook-level 
    is good based on time elapsed.
    
    Determine what's a good cook level by initially watching your 
    animation to see which time range the egg looks sunny-side up. 
    If the time is less than this range, it's under-cooked. If it's
    over the range, the egg is over-cooked.
  */

  //Modify the goodRangeLow and goodRangeHigh with your own values in seconds.
  let goodRangeLow = 0; //in seconds
  let goodRangeHigh = 0; //in seconds

  //Display appropriate status message in .status div
  
}