namespace IUR.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}