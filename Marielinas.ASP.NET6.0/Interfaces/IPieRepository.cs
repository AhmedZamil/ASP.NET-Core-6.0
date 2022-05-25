using Marielinas.ASP.NET6._0.Models;

namespace Marielinas.ASP.NET6._0.Interfaces
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        IEnumerable<Pie> PiesOfTheWeek { get; }
        Pie GetPieById(int PieId);
    }
}
