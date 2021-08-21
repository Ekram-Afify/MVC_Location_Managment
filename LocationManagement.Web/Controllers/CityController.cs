using LocationManagement.Data;
using LocationManagement.Services;
using LocationManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocationManagement.Web.Controllers
{
   
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
     
        public CityController(ICityService cityService, ICountryService countryService)
        {
           
            _cityService = cityService;
            _countryService = countryService;
        }
        // GET: /City
        public ActionResult Index()
        {
            ViewBag.CountryList = _countryService.GetList();
            return View(new CityCreateViewModel());
        }

    

        public ActionResult LoadData(int countryId = -1,string text="",int pageIndex=0,int pageSize=20)
        {
            var data = _cityService.Search(text,countryId,"ID",false,pageIndex,pageSize);
            return Json(new { data = data.Result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
              return View(new CityCreateViewModel());
        }
        [HttpPost]
        public ActionResult Create(CityCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_cityService.IsCityNameExist(viewModel.CityName))
                {
                    _cityService.Create(viewModel);
                    return RedirectToAction("Index", "City");
                }

                else
                {
                    ViewBag.CountryList = _countryService.GetList();
                    ModelState.AddModelError(string.Empty, "City Name is alreay Exist");
                    return View("Index", viewModel);
                

                }
            }
            return PartialView(viewModel);

        }
        public ActionResult Edit(int id)
        {

            var City = _cityService.GetById(id);
            ViewBag.Countries = _countryService.GetList();
            return View(City);
        }
        [HttpPost]
        public ActionResult Edit(CityCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!_cityService.IsCityNameExistById(viewModel.CityName, viewModel.ID))
                    {
                        _cityService.Update(viewModel);
                        return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        ViewBag.Countries = _countryService.GetList();
                        ModelState.AddModelError(string.Empty, "City Name is alreay Exist");
                       return PartialView(viewModel);

                    }
                }
                catch(Exception e)
                {

                }
               
            }
            return PartialView(viewModel);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _cityService.Delete(id);
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCountries()
        {
            var countries = _countryService.GetList();
            return Json( countries, JsonRequestBehavior.AllowGet);
        }
    }
}