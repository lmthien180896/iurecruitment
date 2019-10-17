using IUR.Data.Infrastructure;
using IUR.Model.Models;

namespace IUR.Data.Repositories
{
    public interface IApplicantJobRepository : IRepository<ApplicantJob>
    {
    }

    public class ApplicantJobRepository : RepositoryBase<ApplicantJob>, IApplicantJobRepository
    {
        public ApplicantJobRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}