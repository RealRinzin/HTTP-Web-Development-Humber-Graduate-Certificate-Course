//LAB 9-DATA STORAGE: INDEX PAGE
//window.onload

window.onload = init;

function init() {

    var removeBtn = document.getElementById('btnDel');
    var user_name = document.getElementById('newMsgBox');
    // form 
    var formHandle = document.forms.infoForm;
    // document.body.style.backgroundColor = 'red';
    // Process the form
    formHandle.onsubmit = processForm;


    if (document.cookie.length > 0) {
        var allCookies = document.cookie.split(";")
        var name = allCookies[0].split("=")[1];
        var color = allCookies[1].split("=")[1];
        document.body.style.backgroundColor = color;
        user_name.innerHTML = `Welcome ${name}`;

    }

    // Form handle function
    function processForm() {
        var userName = formHandle.f_name.value;
        var userColor = formHandle.f_color.value;
        var cookieLifeSpan = 24000;

        // For the Username
        makeCookie('UserName', userName, cookieLifeSpan)
        // For the User Color
        makeCookie('UserColor', userColor, cookieLifeSpan)

        // Function to store the cookie values 
        function makeCookie(cookieName, cookieValue, lifeSpan) {
            document.cookie = `${cookieName}=${cookieValue};max-age=${lifeSpan}`
        }
    }
    // Remove Cookies
    function removeCookies() {
        console.log("remove");
        // For the Username
        document.cookie = "UserName=x; max-age=0;";
        // For the User Color
        document.cookie = "UserColor=y; max-age=0;";
        window.location.reload()
        // console.log("Remove Cookies")

    }
    // return false;
    removeBtn.onclick = removeCookies;


}






