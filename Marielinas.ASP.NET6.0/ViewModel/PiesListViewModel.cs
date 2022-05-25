using Marielinas.ASP.NET6._0.Models;

namespace Marielinas.ASP.NET6._0.ViewModel
{
    public class PiesListViewModel
    {
        public IEnumerable<Pie> Pies { get; set; }
        public string CurrentCategory { get; set; }
    }
}
