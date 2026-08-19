// Car
// Getting the random number (1-3) for the variable car
let switchCounter = 0;
let stayCounter = 0;
for (let i = 1; i <= 100; i++) {
    const car = Math.ceil(Math.random() * 3);
    // console.log(`The card is behind door no:${car}`)
    // step 2 Part pick to door
    // console.log('****************************************')
    const choice = Math.ceil(Math.random() * 3);
    //  Step 3 remove 
    // console.log('****************************************')
    let remove;
    // console.log(`The removed door:${remove}`)
    // Step 4
    do (
        remove = Math.ceil(Math.random() * 3)

    )
    while (remove === car || remove === choice);

    if (car === choice) {
        // console.log(`Should have Stayed${stayCounter}`)
        stayCounter++;
    } else {
        // console.log(`Should have switched${switchCounter}`)
        switchCounter++;
    }

}
document.write(`<p style='color:red'> Stay ${((stayCounter / 100) * 100).toFixed(1)}%</p>`)
document.write(`<p style='color:green'> Switch ${((switchCounter / 100) * 100).toFixed(1)}%</p>`)
// console.log(`Total Stay Count : ${((stayCounter / 1000) * 100).toFixed(1)}%`)
// console.log(`Total Switch Count : ${((switchCounter / 1000) * 100).toFixed(1)}%`)

// console.log(`Stay Percentage:${((stayCounter / 100) * 100).toFixed(2)} %`)
// console.log(`Stay Percentage:${((switchCounter / 100) * 100).toFixed(2)} %`)
