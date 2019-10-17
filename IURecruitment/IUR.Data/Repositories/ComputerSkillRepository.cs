using IUR.Data.Infrastructure;
using IUR.Model.Models;

namespace IUR.Data.Repositories
{
    public interface IComputerSkillRepository : IRepository<ComputerSkill>
    {
    }

    public class ComputerSkillRepository : RepositoryBase<ComputerSkill>, IComputerSkillRepository
    {
        public ComputerSkillRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}