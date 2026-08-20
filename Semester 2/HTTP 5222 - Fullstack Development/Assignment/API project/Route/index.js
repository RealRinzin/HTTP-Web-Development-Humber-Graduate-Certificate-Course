import { Router } from "express";
import api from "../API/index.js"
const router = Router();

router.get("/", async (request, response) => {
    const res = await api.getHTTPMethod(`${process.env.JOB_API_ENDPOINT}/remote-jobs`,"GET","")
    const countries = await api.getHTTPMethod(`${process.env.COUNTRIES_API_ENDPOINT}?memberships.g7=1&pretty=1`,"GET",`${process.env.COUNTRIES_API_KEY}`)
    console.log(countries.data.objects)
    response.render("index",{jobs:res.jobs,countries:countries.data.objects});
});

export default router;