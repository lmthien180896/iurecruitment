using IUR.Data.Infrastructure;
using IUR.Model.Models;

namespace IUR.Data.Repositories
{
    public interface IOtherQuestionRepository : IRepository<OtherQuestion>
    {
    }

    public class OtherQuestionRepository : RepositoryBase<OtherQuestion>, IOtherQuestionRepository
    {
        public OtherQuestionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}