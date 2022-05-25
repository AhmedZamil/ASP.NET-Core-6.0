using Marielinas.ASP.NET6._0.Interfaces;
using Marielinas.ASP.NET6._0.Models;
using Microsoft.EntityFrameworkCore;

namespace Marielinas.ASP.NET6._0.Repository
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext _dbContext;

        public PieRepository(AppDbContext DbContext)
        {
            _dbContext = DbContext;
        }
        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _dbContext.Pies.Include(c=>c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek {
            get {
                return _dbContext.Pies.Include(c=>c.Category).Where(p => p.IsPieOfTheWeek == true).ToList();
            }
        
        }

        public Pie GetPieById(int PieId)
        {
            return _dbContext.Pies.Include(c=>c.Category).FirstOrDefault(p => p.PieId == PieId);
        }
    }
}
