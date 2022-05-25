using Marielinas.ASP.NET6._0.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marielinas.ASP.NET6._0.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryMenu(ICategoryRepository CategoryRepository)
        {
            _categoryRepository = CategoryRepository;
        }

        public IViewComponentResult Invoke() 
        {
            var categories = _categoryRepository.AllCategories;
            return View(categories);
        }
    }
}
