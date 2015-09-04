using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Destination2.WebUi.Search.Entities;
namespace Destination2.WebUi.Search.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(SearchForm model)
        {
           
            return View(model);
        }

        // GET: Home/Create
        public ActionResult DisplayForm()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(SearchForm model)
        {
            try
            {

                string backge = model.IsPackage;
                string fili = model.NumberOfChildren;
               
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
       
    }
}
