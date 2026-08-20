// Import the functions you need from the SDKs you need
import { initializeApp } from 'https://www.gstatic.com/firebasejs/12.14.0/firebase-app.js'
import { getDatabase, ref, child, get, push, set, onValue, onChildAdded, serverTimestamp } from "https://www.gstatic.com/firebasejs/12.14.0/firebase-database.js";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
    apiKey: "AIzaSyB83veug18efWo-EUbWRFqSOlrSLD52FnE",
    authDomain: "fir-app-87996.firebaseapp.com",
    projectId: "fir-app-87996",
    storageBucket: "fir-app-87996.firebasestorage.app",
    messagingSenderId: "813655295108",
    appId: "1:813655295108:web:4516f167b8c6bc2b296ed1",
    measurementId: "G-18YR49STZ2"
};
// Initialize Firebase
const app = initializeApp(firebaseConfig);
// const analytics = getAnalytics(app);


const databse = getDatabase();

const messages = ref(databse, "/messages")

onValue(
    messages,
    (snapshot) => {
        let ul = document.getElementById('messages');
        ul.replaceChildren();
        snapshot.forEach((childSnapshot) => {
            const key = childSnapshot.key;
            const data = childSnapshot.val();

            let li = document.createElement("li");

            let text = document.createTextNode(
                data.message + " - " + data.name
            )
            li.append(text);
            ul.append(li);
        });
    }
);

const add = document.getElementById('add');
add.addEventListener("click", function () {

    let name = document.getElementById("name")
    let message = document.getElementById("message")


    let newMessage = push(messages);

    set(
        newMessage,
        {
            name: name.value,
            message: message.value,
            date: serverTimestamp()
        }
    )
})
