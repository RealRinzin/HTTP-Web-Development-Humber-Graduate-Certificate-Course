//LAB 9-DATA STORAGE: PRODUCTS PAGE

//LAB 9-DATA STORAGE: INDEX PAGE
//window.onload

window.onload = init;
var removeBtn = document.getElementById('btnDel');
var user_name = document.getElementById('newMsgBox');

function init(){
            // document.body.style.backgroundColor = 'red';
    // Process the form


    if(document.cookie.length>0){
        var allCookies = document.cookie.split(";")
        var name = allCookies[0].split("=")[1];
        var color = allCookies[1].split("=")[1];
document.body.style.backgroundColor = color;
user_name.innerHTML = `Welcome ${name}?''`;

    }



}



    