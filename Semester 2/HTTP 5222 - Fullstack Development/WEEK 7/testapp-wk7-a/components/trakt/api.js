const trakt = "https://api.trakt.tv"; //base URL for any Trakt API requests

/*
 * Functions for Trakt API requests.
 */

//Function to retrieve a list of trending movies.
async function getTrendingMovies() {
  let reqUrl = `${trakt}/movies/trending?extended=images`;
  let result = await fetch(
    reqUrl, //first parameter is the request URL
    {
      method: "get", //this is optional if "get" (default), but needs to be set if "post"
      headers: {
        "Content-Type": "application/json",
        "User-Agent": "TestApp/1.0.0",
        "trakt-api-key": process.env.TRAKT_CLIENT_ID,
        "trakt-api-version": 2
      }
    } //second parameter is request options JSON object
  );
  return await result.json();
}
//Function to retrieve a list of studios by IMDB movie ID
async function getStudiosByMovieId(slug) {
  let reqUrl = `${trakt}/movies/${slug}/studios`;
  let result = await fetch(
    reqUrl,
    {
      headers: {
        "Content-Type": "application/json",
        "User-Agent": "TestApp/1.0.0",
        "trakt-api-key": process.env.TRAKT_CLIENT_ID,
        "trakt-api-version": 2
      }
    }
  );
  return await result.json();
}

async function getAllTheShows() {
  let reqUrl = `${trakt}/shows/trending?extended=images`;
  let result = await fetch(
    reqUrl,
    {
      headers: {
        "Content-Type": "application/json",
        "User-Agent": "TestApp/1.0.0",
        "trakt-api-key": process.env.TRAKT_CLIENT_ID,
        "trakt-api-version": 2
      }
    }
  );
  return await result.json();
}

// Get the show by ID
async function getShowById(showId) {
  let reqUrl = `${trakt}/shows/${showId}?extended=full`;
  let result = await fetch(
    reqUrl,
    {
      headers: {
        "Content-Type": "application/json",
        "User-Agent": "TestApp/1.0.0",
        "trakt-api-key": process.env.TRAKT_CLIENT_ID,
        "trakt-api-version": 2
      }
    }
  );
  return await result.json();

}

export default {
  getTrendingMovies,
  getStudiosByMovieId,
  getAllTheShows,
  getShowById
};