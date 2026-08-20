import express from "express";
import { MongoClient } from "mongodb";
import cors from "cors";
import mongoose from "mongoose";
import "dotenv/config";

import path from "path";
import { getJobs } from "./utils/api.js";

// Get the path of the current file
const __dirname = import.meta.dirname;
// Create an instance of express
const app = express();
app.use(express.json());
app.use(cors());
const port = process.env.PORT || 9002;
// ================= MongoDB Connection ===========================
// connect to MongoDB
const dbUrl = `${process.env.MONGO_URI}${process.env.DB_NAME}`;
mongoose
    .connect(dbUrl)
    .then(() => console.log("Connected to MongoDB"))
    .catch((err) => console.log("MongoDB connection error:", err));
// ==================== Page Route =================================
app.get("/", async (req, res) => {
    const jobs = await getJobs();
    res.json({jobs});
});
app.get("/jobs", async (req, res) => {
    const jobs = await getJobs();
    res.json({jobs});
});
app.listen(port, () => {
  console.log(`Listening on http://localhost:${port}`);
});