//import required modules
import express from "express";
import path from "path";
import "dotenv/config";

import api from "./api/Endpoint.js";

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
  // let games = await api.getTheGames();
  let price = await api.getThePrice();
  console.log(price);
  response.render("index", { price: price.results });
});



//set up server listening
app.listen(port, () => {
  console.log(`Listening on http://localhost:${port}`);
});


