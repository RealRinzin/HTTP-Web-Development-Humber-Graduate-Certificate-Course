# JavaScript Slideshow

A basic vanilla JavaScript slideshow.

## Coding from Scratch

When coding something like a JavaScript slideshow, half of the problem is understanding how to split the lager objective into small steps. Download a copy of the `index.html`, `styles.caa`, and `slideshow.js` files and then follow these steps. Do not proceed to the next step until the current one is done and tested. 

1. The images all need to be stacked on top of each other instead of underneath each other. Use CSS to place the images on top of each other.
  
2. Only one image meedds to be visible at a time. Use CSS to hide all the images but the first one.
   
3. In the `slideshow.js` file, define a `current` variable to track the current image. Set it to zero. This variable will go form zero, to three, and then back to zero (because there ar four images).

4. Define a `total` variable to track the number of images. Set it to four.

5. Add a click event to the next button. For now `console.log()` the word "next" when the button is clicked. This will confirm that the button is working.

6. Inside the `next` button click event, increase `current` variable by one. Use `console.log()` to confirm that the variable has increased.

7. Inside the `next` button click event, add an if statement that will reset the `current` variable to zero when the `current` variable is too high.

8. Inside the `next` button click event, hide all images and then display the image based on the number inside the `current` variable. 

9. Redo steps five through eight except for a previous button.

10. Using JavaScript `setInterval()` function, make the slideshow automatically change images every five seconds.

> [!Note]
> There are sample code files for steps one through six. Try to complete each step without the samples. Use them as a last resort.

***

## Repo Resources

* [Visual Studio Code](https://code.visualstudio.com/)

<br>
<a href="https://codeadam.ca">
<img src="https://cdn.codeadam.ca/images@1.0.0/codeadam-logo-coloured-horizontal.png" width="200">
</a>
