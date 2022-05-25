using Marielinas.ASP.NET6._0.Models;

namespace Marielinas.ASP.NET6._0.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> AllCategories { get; }
    }
}
