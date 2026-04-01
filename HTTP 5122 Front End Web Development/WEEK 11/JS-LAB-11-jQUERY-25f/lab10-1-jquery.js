//LAB 10 - 1 FAQ PAGE

//Listen for window load the jQuery way

jQuery(document).ready(function () {

	// Hide all the content tabs on page load
	$('.contentBox').hide();
	//Inside of here is your jQuery/JavaScript
	//ADD CLICK EVENT TO <h2>
	$("h2").on("click", function () {
		// $(this).next("p").fadeToggle("slow");
		$(this).next("p").slideToggle(1000);
	});

	// Close all other content when one is clicked
	$("h2").on("click", function () {
		$("h2").not(this).next("p").slideUp(1000);
	});

	//CHANGE <p> BACKGROUND ON HOVER
	$("p").hover(
		function () {
			$(this).toggleClass("textHovered");
			$(this).css("cursor", "pointer");

		},
		function () {
			$(this).toggleClass("textHovered");
			$(this).css("cursor", "pointer");

		}
	);



});


