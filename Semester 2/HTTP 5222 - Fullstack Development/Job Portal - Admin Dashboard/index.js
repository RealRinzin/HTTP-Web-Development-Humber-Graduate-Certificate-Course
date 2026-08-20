import express from "express";
import mongoose from "mongoose";
import path from "path";
import "dotenv/config";
// API File
// import { getAllCompanies } from "./utils/api.js"
import { getAllCompanies } from "./utils/api/company.js"
import { getAllJobs, getThisJob } from "./utils/api/job.js";
// Directory
const __dirname = import.meta.dirname;


//set up Express app
const app = express();
//You need the following two lines of code if you want to access GET or POST data as if they were JSON objects
//Set Express to extend the URLencoded format and use JSON
app.use(express.urlencoded({ extended: true }));
app.use(express.json());
const port = process.env.PORT || 9998;
// Set Default App View
app.set("view engine", "pug");
//setup public folder
// app.use(express.static(path.join(__dirname, "public")));
app.use(express.static("public"));

// ================= MongoDB Connection ===========================
// connect to MongoDB
const dbUrl = `${process.env.MONGO_URI}${process.env.DB_NAME}`;
mongoose
    .connect(dbUrl)
    .then(() => console.log("Connected to MongoDB"))
    .catch((err) => console.log("MongoDB connection error:", err));
// ==================== Page Route =================================
// Home
app.get("/", async (request, response) => {
    const jobs = await getAllJobs();
    response.render("index", { title: "Home",jobs });
});
// ==================== Job Route =================================
// GET
app.get("/jobs", async (request, response) => {
    const jobs = await getAllJobs();
    response.render("job/index", { title: "Jobs", jobs });
});
// GET
app.get("/jobs/:id", async (req, res) => {
    const job = await getThisJob(req.params.id);
    if (!job) {
        return res.status(404).send("Job not found");
    }

    res.render("job/view", { job });
});
// ==================== Companies Route =================================
// GET
app.get("/companies", async (request, response) => {
    const companies = await getAllCompanies();
    response.render("company/index", { title: "Companies", companies });
});


// App Lister
app.listen(port, () => {
    console.log(`Listening on http://localhost:${port}`);
});