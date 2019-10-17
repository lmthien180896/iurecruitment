using IUR.Data.Infrastructure;
using IUR.Model.Models;

namespace IUR.Data.Repositories
{
    public interface IOtherSkillRepository : IRepository<OtherSkill>
    {
    }

    public class OtherSkillRepository : RepositoryBase<OtherSkill>, IOtherSkillRepository
    {
        public OtherSkillRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}