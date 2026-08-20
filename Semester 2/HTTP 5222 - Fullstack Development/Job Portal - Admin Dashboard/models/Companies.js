import mongoose from "mongoose";


const CompanySchema = new mongoose.Schema({

    name: String,
    type: String,
    description: String,
    logo: String

});


export default mongoose.model("Company", CompanySchema);