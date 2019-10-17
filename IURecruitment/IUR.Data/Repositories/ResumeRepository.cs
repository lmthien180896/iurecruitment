using IUR.Data.Infrastructure;
using IUR.Model.Models;

namespace IUR.Data.Repositories
{
    public interface IResumeRepository : IRepository<Resume>
    {
    }

    public class ResumeRepository : RepositoryBase<Resume>, IResumeRepository
    {
        public ResumeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}