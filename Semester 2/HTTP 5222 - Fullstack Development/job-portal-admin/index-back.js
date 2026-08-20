require("dotenv").config();
const express = require("express");
const mongoose = require("mongoose");
const path = require("path");

const Company = require("./models/Company");
const Job = require("./models/Job");

const app = express();
const PORT = process.env.PORT || 9005;

// connect to MongoDB
mongoose
  .connect(process.env.MONGO_URI)
  .then(() => console.log("Connected to MongoDB"))
  .catch((err) => console.log("MongoDB connection error:", err));

// view engine setup
app.set("view engine", "pug");
app.set("views", path.join(__dirname, "views"));

// middleware
app.use(express.urlencoded({ extended: true })); // to read form data
app.use(express.static(path.join(__dirname, "public")));

// ---------- ADMIN DASHBOARD ----------
app.get("/", (req, res) => {
  res.render("index");
});

// ---------- COMPANIES (admin pages) ----------

// show all companies + add form
app.get("/companies", async (req, res) => {
  const companies = await Company.find();
  res.render("companies", { companies });
});

// add a new company
app.post("/companies", async (req, res) => {
  const { name, description } = req.body;
  await Company.create({ name, description });
  res.redirect("/companies");
});

// delete a company
app.post("/companies/:id/delete", async (req, res) => {
  await Company.findByIdAndDelete(req.params.id);
  res.redirect("/companies");
});

// ---------- JOBS (admin pages) ----------

// show all jobs + add form
app.get("/jobs", async (req, res) => {
  const jobs = await Job.find().populate("company");
  const companies = await Company.find();
  res.render("jobs", { jobs, companies });
});

// add a new job
app.post("/jobs", async (req, res) => {
  const { title, description, role, company } = req.body;
  await Job.create({ title, description, role, company });
  res.redirect("/jobs");
});

// delete a job
app.post("/jobs/:id/delete", async (req, res) => {
  await Job.findByIdAndDelete(req.params.id);
  res.redirect("/jobs");
});

// ---------- JSON API ENDPOINTS ----------

// GET /api/companies - returns all companies as JSON
app.get("/api/companies", async (req, res) => {
  const companies = await Company.find();
  res.json(companies);
});

// GET /api/jobs - returns all jobs as JSON (with company info included)
app.get("/api/jobs", async (req, res) => {
  const jobs = await Job.find().populate("company");
  res.json(jobs);
});

app.listen(PORT, () => {
  console.log(`Server running on http://localhost:${PORT}`);
});
