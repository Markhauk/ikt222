// Get every carousel object on frontpage (1) 


// The slideshow goes in a loop and is changing automatic
var slideIndex = 0;
carousel();

function carousel() {
    var i;
    var x = document.getElementsByClassName("carousel__item");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    slideIndex++;
    if (slideIndex > x.length) {slideIndex = 1}
    x[slideIndex-1].style.display = "block";
    setTimeout(carousel, 5000);
}


//Buttons and things for changing the slides 
document.querySelectorAll(".carousel").forEach(carousel =>
{
    // Get every carousel item in carousel object (3) 
    const items = carousel.querySelectorAll(".carousel__item");

    // Create an array of html for each button  
    // Size is equal to amount of carousel items (3) 
    const buttonsHTML = Array.from(items, () =>
    {
        return '<span class="carousel__button"></span>';
    });

    // Generate carousel__nav  
    carousel.insertAdjacentHTML(
        "beforeend",
        ` 
      <div class="carousel__nav"> 
         ${buttonsHTML.join("")} 
      </div> 
   `
    );


    // Activate buttons  
    const buttons = carousel.querySelectorAll(".carousel__button");

    // Loop through buttons and add event listener 
    buttons.forEach((button, i) => {
        button.addEventListener("click", () => {
            // Unselect all carousel items 
            items.forEach(item => item.classList.remove("carousel__item--selected"));
            buttons.forEach(button => button.classList.remove("carousel__button--selected"));

            items[i].classList.add("carousel__item--selected");
            button.classList.add("carousel__item--selected");
        });
    });

    // Select first item on page load 
    items[0].classList.add("carousel__item--selected");
    buttons[0].classList.add("carousel__item--selected");

}); 