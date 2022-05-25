using Marielinas.ASP.NET6._0.Interfaces;
using Marielinas.ASP.NET6._0.Models;

namespace Marielinas.ASP.NET6._0.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext Context)
        {
            _context = Context;
        }
        public List<Category> AllCategories 
        {
            get {
                return _context.Categories.OrderBy(c=>c.CategoryName).ToList();
            }
        }
    }
}
