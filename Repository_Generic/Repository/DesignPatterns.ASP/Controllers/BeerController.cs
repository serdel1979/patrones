using DesignPatterns.ASP.ViewsModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Patterns.UnitOW.Entities;
using UnitOffWork;

namespace DesignPatterns.ASP.Controllers
{
    public class BeerController : Controller
    {
        private readonly IUnitOffWork _unitOffWork;

        public BeerController(IUnitOffWork unitOffWork)
        {
            _unitOffWork = unitOffWork;
        }
        public IActionResult Index()
        {

            IEnumerable<BeerViewModel> beers =
                from d in _unitOffWork.Beers.Get()
                select new BeerViewModel
                {
                    BeerId = d.BeerId,
                    Name = d.Name,
                    Style = d.Style
                };
            return View("Index", beers);
        }

        [HttpGet]
        public IActionResult Add()
        {

            var brands = _unitOffWork.Brands.Get();
            ViewBag.Brands = new SelectList(brands, "BrandId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Add(FormBeerViewModel beerVM)
        {

            if (!ModelState.IsValid)
            {
                var brands = _unitOffWork.Brands.Get();
                ViewBag.Brands = new SelectList(brands, "BrandId","Name");
                return View("Add", beerVM);
            }

            var beer = new Beer();
            beer.Name = beerVM.Name;
            beer.Style = beerVM.Style;

            if (beerVM.BrandId == null)
            {
                var brand = new Brand();
                brand.Name = beerVM.OtherBrand;
                brand.BrandId = Guid.NewGuid();
                beer.BrandId = brand.BrandId;
                _unitOffWork.Brands.Add(brand);
            }
            else
            {
                beer.BrandId = (Guid)beerVM.BrandId;
            }

            _unitOffWork.Beers.Add(beer);
            _unitOffWork.Save();

            return RedirectToAction("Index");
        }





    }
}
