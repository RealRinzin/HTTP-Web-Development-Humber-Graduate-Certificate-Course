// import Company from "../models/Companies.js";
import Job from "../models/jobs.js";

// Get the List of all the companies
async function getJobs() {
    try {
        const jobs = await Job.find(); // fetch all documents
        return jobs;
    } catch (error) {
        console.error(error);
        return []; // or throw error, depending on how you want to handle it upstream
    }
}

export { getJobs }