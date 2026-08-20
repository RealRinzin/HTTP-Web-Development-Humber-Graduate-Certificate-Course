// import Company from "../models/Companies.js";
import Job from "../../models/Jobs.js";

// Get the List of all the companies
async function getAllJobs() {
    try {
        const jobs = await Job.find(); // fetch all documents
        return jobs;
    } catch (error) {
        console.error(error);
        return []; // or throw error, depending on how you want to handle it upstream
    }
}
// GET job:ID
async function getThisJob(id) {
    try {
        const job = await Job.findById(id);
        return job;
    } catch (error) {
        console.error(error);
        return null;
    }
}
export { getAllJobs,getThisJob }