using DesignPatterns.ASP.ViewsModel;
using Microsoft.AspNetCore.Mvc;
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
    }
}
