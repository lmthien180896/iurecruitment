using IUR.Data.Infrastructure;
using IUR.Model.Models;

namespace IUR.Data.Repositories
{
    public interface ILanguageRepository : IRepository<Language>
    {
    }

    public class LanguageRepository : RepositoryBase<Language>, ILanguageRepository
    {
        public LanguageRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}