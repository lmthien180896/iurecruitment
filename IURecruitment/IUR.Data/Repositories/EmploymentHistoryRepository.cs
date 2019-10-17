using IUR.Data.Infrastructure;
using IUR.Model.Models;

namespace IUR.Data.Repositories
{
    public interface IEmploymentHistoryRepository : IRepository<EmploymentHistory>
    {
    }

    public class EmploymentHistoryRepository : RepositoryBase<EmploymentHistory>, IEmploymentHistoryRepository
    {
        public EmploymentHistoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}