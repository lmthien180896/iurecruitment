using IUR.Data.Infrastructure;
using IUR.Model.Models;

namespace IUR.Data.Repositories
{
    public interface IRankRepository : IRepository<Rank>
    {
    }

    public class RankRepository : RepositoryBase<Rank>, IRankRepository
    {
        public RankRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}