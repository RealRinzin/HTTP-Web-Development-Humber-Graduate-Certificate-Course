window.onload = init;
// MY API KEY
// 4f167c4bc5aba13711a86efc1bd11fe1
// Initialize the Init
function init() {
    // Location
    var location = document.getElementById('location');
    // temperature
    var temperature = document.getElementById('temperature');
    // condition
    var conditions = document.getElementById('conditions');
    var hTemperature = document.getElementById('human_temperature');
    var hCondition = document.getElementById('human_conditions');
    // OpenWeather endpoint api
    const endpoint = `https://api.openweathermap.org/data/2.5/weather?q=toronto&units=metric&appid=4f167c4bc5aba13711a86efc1bd11fe1`;

    // Create XMLHttpRequest Object
    var xhr = new XMLHttpRequest();
    // Send the request to end point
    xhr.open('GET', endpoint, true);
    // Request response type JSON
    xhr.responseType = 'json';
    xhr.send(null);

    // Call the ready function

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4) {
            // Check if response status 200 | 404 | 500 etc..
            if (xhr.status === 200) {
                var data = xhr.response;
                console.log(data);
                // Location output
                location.innerHTML = data.name;
                // temperature
                temperature.innerHTML = data.main.temp.toFixed(0);
                // conditions
                conditions.innerHTML = data.weather[0].description

                /**
                 * 
                 * Human Readable Format for Temperature and Condition
                 *  */
                // Weather 
                hTemperature.innerHTML = `${data.main.temp.toFixed(0)}&deg;C`;
                hCondition.innerHTML = `${data.weather[0].description.charAt(0).toUpperCase()}${data.weather[0].description.slice(1)}.`

            } else {
                location.innerHTML = `<p style='color:red'>API call Failed. Please try again !!!</p>`;
                console.log(xhr.status)
            }
        }
    }

}