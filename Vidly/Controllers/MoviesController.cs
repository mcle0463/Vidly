﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie(){Name = "Shrek!"};
            return View(movie);
           // return RedirectToAction("Index", "Home", new {page=1, sortBy="name"});
        }

        public ActionResult Edit(int Id)
        {
            return Content("Id"+ Id);

        }
        // movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (sortBy.IsNullOrWhiteSpace())
                sortBy = "Name";
            return Content(String.Format("pageIndex = {0}, sortBy = {1}", pageIndex, sortBy));
        }
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(range(1,12))}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);

        }
    }
}