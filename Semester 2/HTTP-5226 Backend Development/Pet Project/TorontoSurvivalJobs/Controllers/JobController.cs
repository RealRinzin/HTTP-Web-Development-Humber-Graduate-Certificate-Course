using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TorontoSurvivalJobs.Models;
using TorontoSurvivalJobs.Services;

namespace TorontoSurvivalJobs.Controllers;

public class JobController : Controller
{
    private readonly JobService _jobService;
    public JobController(JobService jobService)
    {
        _jobService = jobService;
    }

    // View 
    public IActionResult Index()
    {
        var jobs = _jobService.getAllJobs();
        return View(jobs);
    }

    // Add view
    public IActionResult Add()
    {
        return View();
    }

    // Edit View
    public IActionResult Edit()
    {
        return View();
    }
    // HTTP METHODS 
    [HttpGet]
    public async Task<IActionResult> Detail(int id)
    {
        var job = _jobService.getJob(id);

        if (job == null)
        {
            return NotFound(); // good practice
        }

        return View(job);
    }

    // Create New Job
    [HttpPost]
    public IActionResult Create(Job job)
    {
        _jobService.CreateJob(job);
        return RedirectToAction("index");
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        _jobService.DeleteJob(id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var job = _jobService.getJob(id);
        if (job == null)
        {
            return NotFound();
        }

        return View(job);
    }
    // POST JOB
    [HttpPost]
    public IActionResult Edit(Job job)
    {
        _jobService.UpdateClient(job);
        return RedirectToAction("Index");
    }

}
