

// HTTP Get Method
async function getHTTPMethod(url,method,bearer) {
    const res = await fetch(url, {
        method: method,
        headers: {
            "Content-Type": "application/json",
            "User-Agent": "myappdev/1.0.0",
            "Authorization": `Bearer ${bearer}`
        }
    })
    return await res.json();
}

export default {getHTTPMethod}