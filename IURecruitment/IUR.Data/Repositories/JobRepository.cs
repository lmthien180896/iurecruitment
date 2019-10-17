using IUR.Data.Infrastructure;
using IUR.Model.Models;

namespace IUR.Data.Repositories
{
    public interface IJobRepository : IRepository<Job>
    {
    }

    public class JobRepository : RepositoryBase<Job>, IJobRepository
    {
        public JobRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}