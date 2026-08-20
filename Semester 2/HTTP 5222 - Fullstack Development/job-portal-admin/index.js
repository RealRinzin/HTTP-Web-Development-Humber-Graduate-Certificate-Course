import express from "express";
import path from "path";
import "dotenv/config";

const __dirname = import.meta.dirname;

//set up Express app
const app = express();
const port = process.env.PORT || 9010;
// Set Default App View
app.set("view engine", "pug");

// ==================== Page Route =================================
// Home
app.get("/", (request, response) => {
    response.render("index");
});

// App Lister
app.listen(port, () => {
    console.log(`Listening on http://localhost:${port}`);
});