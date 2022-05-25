using Marielinas.ASP.NET6._0.Interfaces;
using Marielinas.ASP.NET6._0.Models;
using Marielinas.ASP.NET6._0.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Marielinas.ASP.NET6._0.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository PieRepository,ICategoryRepository CategoryRepository)
        {
            _pieRepository = PieRepository;
            _categoryRepository = CategoryRepository;
        }
        public IActionResult Index() 
        {
            PiesListViewModel piesListViewModel = new PiesListViewModel();

            piesListViewModel.Pies = _pieRepository.AllPies.OrderBy(p=>p.PieId);
            piesListViewModel.CurrentCategory = "All Pies";

            return View();
        }
        public IActionResult List(string Category)
        {
            IEnumerable<Pie> Pies;
            string CurrentCategory = string.Empty;

            if (string.IsNullOrEmpty(Category))
            {
                Pies = _pieRepository.AllPies.OrderBy(p => p.PieId);
                CurrentCategory = "All Pies";
            }
            else
            {
                Pies = _pieRepository.AllPies.Where(p => p.Category.CategoryName == Category).OrderBy(p => p.PieId);
                CurrentCategory = _categoryRepository.AllCategories.Where(c => c.CategoryName == Category).FirstOrDefault()?.CategoryName;
            }

            return View(new PiesListViewModel {Pies = Pies, CurrentCategory = CurrentCategory });  
        }

        public IActionResult Details(int pieId) 
        {
            var pie = _pieRepository.GetPieById(pieId);
            if (pie == null)
            {
                return NotFound();
            }
            return View(pie);
        }
    }
}
