using Marielinas.ASP.NET6._0.Interfaces;
using Marielinas.ASP.NET6._0.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Marielinas.ASP.NET6._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository PieRepository)
        {
            _pieRepository = PieRepository;
        }
        public IActionResult Index()
        {
            PiesListViewModel pieListViewModel = new PiesListViewModel();
            pieListViewModel.Pies = _pieRepository.PiesOfTheWeek;
            pieListViewModel.CurrentCategory = "Best Selling Pies Of the Week";
            return View(pieListViewModel);
        }
    }
}
