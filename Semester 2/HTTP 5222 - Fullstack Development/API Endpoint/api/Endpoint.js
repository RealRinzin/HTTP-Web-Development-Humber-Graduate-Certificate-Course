const games = "https://api.rawg.io/api/games?key=dec1021d9af44294833d398aea3809dd"; //base URL for any Trakt API requests
const cheapSharks ="https://www.cheapshark.com/api/1.0/games?title=Elden Ring";
//Function to retrieve a list of trending movies.
async function getTheGames() {
  let reqUrl = `${games}`;
  let result = await fetch(
    reqUrl, //first parameter is the request URL
    {
      method: "get", //this is optional if "get" (default), but needs to be set if "post"
      headers: {
        "Content-Type": "application/json",
        "User-Agent": "TestApp/1.0.0",
      }
    } //second parameter is request options JSON object
  );
  return await result.json();
}


async function getThePrice() {
  let reqUrl = `${cheapSharks}`;
  let result = await fetch(
    reqUrl, //first parameter is the request URL
    {
      method: "get", //this is optional if "get" (default), but needs to be set if "post"
      headers: {
        "Content-Type": "application/json",
        "User-Agent": "TestApp/1.0.0",
        // "trakt-api-key": process.env.TRAKT_CLIENT_ID,
        // "trakt-api-version": 2
      }
    } //second parameter is request options JSON object
  );
  return await result.json();
}

export default {getTheGames,getThePrice};