using IUR.Data.Infrastructure;
using IUR.Model.Models;

namespace IUR.Data.Repositories
{
    public interface IApplicantDetailRepository : IRepository<ApplicantDetail>
    {
    }

    public class ApplicantDetailRepository : RepositoryBase<ApplicantDetail>, IApplicantDetailRepository
    {
        public ApplicantDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}