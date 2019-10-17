using IUR.Data.Infrastructure;
using IUR.Model.Models;

namespace IUR.Data.Repositories
{
    public interface ICareerObjectiveRepository : IRepository<CareerObjective>
    {
    }

    public class CareerObjectiveRepository : RepositoryBase<CareerObjective>, ICareerObjectiveRepository
    {
        public CareerObjectiveRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}