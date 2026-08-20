// Import the package
import express from "express";
import { MongoClient } from "mongodb"; // import mongo
import path from "path"; // the path module is used to get the path of the current file

const dbEndpoing = "mongodb+srv://user:cvbkb1UsAvRupP5l@mongodb.byhxl87.mongodb.net/?appName=mongoDB";
// Select the database
const db = new MongoClient(dbEndpoing).db("testdb");

// Get the path of the current file
const __dirname = import.meta.dirname;
// Create an instance of express
const app = express();
const port = process.env.PORT || 9000;

// set up app to use Pug as the template engine
// app.set("views", path.join(__dirname, "templates")); //if you had your views/tempaltes in a folder named "templates"
app.set("view engine", "pug");
// Setup the "pubic" folder as a static path
app.use(express.static(path.join(__dirname, "public")));
// Middleware
app.use(async (req, res, next) => {
    let links = await getLinks();    
    app.locals.menu = links;
    next();
})
// Create a home page route
app.get("/", async (req, res) => {
    let links = await getLinks();
    // res.render("index", { title: "My Secret Closet" ,menu: links });
    res.render("index", { title: "My Secret Closet" });
});

app.get("/about", (req, res) => {
    res.render("about", { title: "About Us - Closet" });
});

// ADMIN page

app.get("/admin", (req, res) => {
    
})
// Start the server
app.listen(port, () => {
    // console.log("Server started on port 5000");
    console.log(`Server running at http://localhost:${port}`);
});





// MONGODB RELATED FUNCTIONS
async function getLinks() {
    let result = await db.collection("menuLinks").find().sort({ weight: 1 }).toArray();
    return result
}

getLinks();