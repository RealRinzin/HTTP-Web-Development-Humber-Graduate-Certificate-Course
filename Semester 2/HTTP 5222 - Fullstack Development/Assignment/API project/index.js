import express, { request, response } from "express";
import path from "path";
import "dotenv/config";
import PageRoute from "./route/index.js"
// Directory path;
const __dirname = import.meta.dirname;
//set up Express app
const app = express();
const port = process.env.PORT || 9988;

//define important folders
app.set("views", path.join(__dirname, "pages"));
app.set("view engine", "pug");

//setup public folder
app.use(express.static(path.join(__dirname, "public")));
// Page Routes"

app.use("/", PageRoute);
app.listen(port, () => {
    console.log(`Listening on http://localhost:${port}`);
});
