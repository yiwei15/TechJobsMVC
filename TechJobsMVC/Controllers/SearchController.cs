﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.jobs = new List<Job>();
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view. 

        [HttpPost]
        [Route("search/results")]
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Job> jobs = new List<Job>();

            if (String.IsNullOrEmpty(searchTerm) || searchTerm == "all")
            {
                jobs = JobData.FindAll();
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }
            ViewBag.jobs = jobs;
            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.searchType = searchType;
            ViewBag.searchTerm = searchTerm;
            return View("index");
        }
    }
}
