// import Company from "../models/Companies.js";
import Company from "../../models/Companies.js";

// Get the List of all the companies
async function getAllCompanies() {
    try {
        const companies = await Company.find(); // fetch all documents
        return companies;
    } catch (error) {
        console.error(error);
        return []; // or throw error, depending on how you want to handle it upstream
    }
}

export {getAllCompanies}