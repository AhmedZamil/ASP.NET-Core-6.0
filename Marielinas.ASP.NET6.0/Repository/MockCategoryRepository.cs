using Marielinas.ASP.NET6._0.Interfaces;
using Marielinas.ASP.NET6._0.Models;

namespace Marielinas.ASP.NET6._0.Repository
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public List<Category> AllCategories => new List<Category> {
                new Category{CategoryId=1, CategoryName="Fruit pies", Description="All-fruity pies"},
                new Category{CategoryId=2, CategoryName="Cheese cakes", Description="Cheesy all the way"},
                new Category{CategoryId=3, CategoryName="Seasonal pies", Description="Get in the mood for a seasonal pie"}
        };
    }
}
