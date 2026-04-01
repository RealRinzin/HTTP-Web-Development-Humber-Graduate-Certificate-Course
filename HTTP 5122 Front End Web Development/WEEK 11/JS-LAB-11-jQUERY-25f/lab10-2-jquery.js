//LAB 10 - 2 INVENTORY PAGE
jQuery(document).ready(function () {
    // Hide the description text on initial load
    $('.desc').hide();

    //ADD MOUSEOVER/MOUSEOUT FUNCTIONS FOR <tr>
    $("tr").hover(
        function () {
            $(this).toggleClass("selected");
            $(this).css("cursor", "pointer");
        },
        function () {
            $(this).toggleClass("selected");
            $(this).css("cursor", "pointer");

        }
    );
    // Individual dispaly of description text when a row is clicked
    $("tr").on("click", function () {
        $('.desc').hide();
        $(this).find(".desc").toggle();
    });
});