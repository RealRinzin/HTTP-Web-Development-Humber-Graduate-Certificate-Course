// Monty Hall Game programming Logics
window.onload = function () {
    var switchCounter =0;
    for (var i = 0; i < 10000; i++) {
        var car = Math.ceil(Math.random() * 3);
        console.log("The car is in the door number " + car);

        var choice = Math.ceil(Math.random() * 3);
        console.log(" The contestant chooses door number " + choice);
        var remove;
        do {
            remove = Math.ceil(Math.random() * 3);
        }
        while (remove == car || remove == choice)

        console.log(" The host removes door number " + remove);

        //output the better choice
        if (choice == car) {
            console.log("The contestant should stay !");
        }
        else {
            console.log("The contestant should switch !");

        }
        if (choice !== car) switchCounter++;

    }
    var percentage = switchCounter / 10000 * 100;
    console.log("\n"+ percentage + " % of the time switch was correct");


}