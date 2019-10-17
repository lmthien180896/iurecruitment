using IUR.Data.Infrastructure;
using IUR.Model.Models;

namespace IUR.Data.Repositories
{
    public interface IEducationBackgroundRepository : IRepository<EducationBackground>
    {
    }

    public class EducationBackgroundRepository : RepositoryBase<EducationBackground>, IEducationBackgroundRepository
    {
        public EducationBackgroundRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}