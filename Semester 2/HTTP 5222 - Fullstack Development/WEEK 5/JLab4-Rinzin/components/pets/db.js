import mongoose from "mongoose";

const dbUrl = `${process.env.MONGO_URI}${process.env.DB_NAME}`;

//set up Schema and model
const MovieSchema = new mongoose.Schema({
  title: String,
  year: Date,
  rating: String,
  poster: String
}); //,  { collection: "pets"});
const Movie = mongoose.model("Movies", MovieSchema);

await mongoose.connect(dbUrl); //if there are user credentials (i.e. user/pwd) in the connection string, use await

//MONGODB FUNCTIONS
/* async function connect() {
  await mongoose.connect(dbUrl); //connect to mongodb
} */

//Function to initialize pets collection with some sample data.
async function initializeMovies() {
const movieArray = [
  {
    title: "The Shawshank Redemption",
    year: new Date("1994-01-01"),
    rating: "R",
    poster: "https://image.tmdb.org/t/p/w500/q6y0Go1tsGEsmtFryDOJo3dEmqu.jpg"
  },
  {
    title: "The Godfather",
    year: new Date("1972-01-01"),
    rating: "R",
    poster: "https://image.tmdb.org/t/p/w500/3bhkrj58Vtu7enYsRolD1fZdja1.jpg"
  },
  {
    title: "The Dark Knight",
    year: new Date("2008-01-01"),
    rating: "PG-13",
    poster: "https://image.tmdb.org/t/p/w500/qJ2tW6WMUDux911r6m7haRef0WH.jpg"
  },
  {
    title: "Pulp Fiction",
    year: new Date("1994-01-01"),
    rating: "R",
    poster: "https://image.tmdb.org/t/p/w500/6l1SV3CWkbbeXj2VxW9v6t5pX3r.jpg"
  },
  {
    title: "Fight Club",
    year: new Date("1999-01-01"),
    rating: "R",
    poster: "https://image.tmdb.org/t/p/w500/bptfVGEQuv6vDTIMVCHjJ9Dz8PX.jpg"
  },
  {
    title: "Forrest Gump",
    year: new Date("1994-01-01"),
    rating: "PG-13",
    poster: "https://image.tmdb.org/t/p/w500/arw2vcBveWOVZr6pxd9XTd1TdQa.jpg"
  },
  {
    title: "Inception",
    year: new Date("2010-01-01"),
    rating: "PG-13",
    poster: "https://image.tmdb.org/t/p/w500/9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"
  },
  {
    title: "Interstellar",
    year: new Date("2014-01-01"),
    rating: "PG-13",
    poster: "https://image.tmdb.org/t/p/w500/gEU2QniE6E77NI6lCU6MxlNBvIx.jpg"
  },
  {
    title: "The Matrix",
    year: new Date("1999-01-01"),
    rating: "R",
    poster: "https://image.tmdb.org/t/p/w500/f89U3ADr1oiB1s9GkdPOEpXUk5H.jpg"
  },
  {
    title: "Gladiator",
    year: new Date("2000-01-01"),
    rating: "R",
    poster: "https://image.tmdb.org/t/p/w500/ty8TGRuvJLPUmAR1H1nRIsgwvim.jpg"
  }
];

  await Movie.insertMany(movieArray);
  console.log("Movies inserted successfully!");
}
//Get all pets from the pets collection
async function getMovies() {
  return await Movie.find({}); //return array for find all
}

//Function to insert one pet
async function addMovie(movieTitle, movieYear, movieRating, moviePoster) {
  let newMovie = new Movie({
    title: String(movieTitle),
    year: String(movieYear),
    rating: String(movieRating),
    poster: String(moviePoster),
  });
  //use save() to save newPet to the DB
  newMovie.save();
}

//Function to update a pet's age by name
// async function updateAgeByName(petName, newAge) {
//   await Pet.updateOne(
//     { name: String(petName) },
//     { age: Number(newAge) }
//   );
// }
// Update Movie
async function updateMovieRating(title, rating) {
  await Movie.updateOne(
    { title: String(title) },
    { rating: String(rating) }
  );
}

//function to delete first pet matched by breed
async function deleteMoviesByRating(rating) {
  await Movie.deleteMany({ rating: String(rating) });
}


export default {
  initializeMovies,
  getMovies,
  addMovie,
  updateMovieRating,
  deleteMoviesByRating
}