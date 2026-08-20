//import required modules
import express from "express";
import path from "path";
import "dotenv/config";

import trakt from "./components/trakt/api.js";

const __dirname = import.meta.dirname;

//set up Express app
const app = express();
const port = process.env.PORT || 9998;

//define important folders
app.set("views", path.join(__dirname, "views"));
app.set("view engine", "pug");
//setup public folder
app.use(express.static(path.join(__dirname, "public")));

//PAGE ROUTES
app.get("/", async (request, response) => {
  let movieList = await trakt.getTrendingMovies();
  console.log(movieList);
  response.render("index", { movies: movieList });
});

app.get("/movie/:slug/studios", async (request, response) => {
  let studioList = await trakt.getStudiosByMovieId(request.params.slug);
  response.render("studios", { studios: studioList });
});

// Assignment
app.get("/trending_shows", async (request, response) => {
  let showList = await trakt.getAllTheShows(request.params.slug);
  response.render("trending_shows", { shows: showList });
});


app.get("/show/:id", async (request, response) => {
  let thisShow = await trakt.getShowById(request.params.id);
  console.log(thisShow)
  response.render("show", { show: thisShow });
});



//set up server listening
app.listen(port, () => {
  console.log(`Listening on http://localhost:${port}`);
});


