import mongoose from "mongoose";

const jobSchema = new mongoose.Schema({
    role: String,
    company: String,
    logo: String,
    location: String,
    type: String,
    description: String,
    posted:String,
    bookmarked:Boolean,
    createdAt: { type: Date, default: Date.now }
});

const Job = mongoose.model("Job", jobSchema);

export default Job;