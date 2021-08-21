using LocationManagement.Data;
using LocationManagement.Services;
using LocationManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IWB.Web.Areas.Admin.Controllers
{

    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;



        public CountryController( ICountryService countryService)
        {

            _countryService = countryService;

        }
        // GET:/Country
        [HttpGet]
        public ActionResult Index()
        {
            return View(new CountryCreateViewModel());
        }

        public ActionResult GetCountries(string text="")
        {
           
            var countries = _countryService.Search(text);

            return Json(new { data = countries.Result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            return View(new CountryCreateViewModel());
        }
        [HttpPost]
        public ActionResult Create(CountryCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_countryService.IsNameExist(viewModel.CountryName))
                {
                    _countryService.Create(viewModel);

                    return RedirectToAction("Index", "Country");
                }
                else
                {
                   ModelState.AddModelError(string.Empty, "Country Name is alreay Exist");
                    return View("Index", viewModel);

                }

            }
            return View("Index", viewModel);
        }
        public ActionResult Edit(int id)
        {
            var country = _countryService.GetById(id);

            return View(country);
        }
        [HttpPost]
        public ActionResult Edit(CountryCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if(!_countryService.IsNameExistById(viewModel.ID, viewModel.CountryName))
                {
                    _countryService.Update(viewModel);
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Country Name is alreay Exist");
                    return PartialView(viewModel);

                }


            }
            return PartialView(viewModel);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _countryService.Delete(id);
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
        }

    }
}
