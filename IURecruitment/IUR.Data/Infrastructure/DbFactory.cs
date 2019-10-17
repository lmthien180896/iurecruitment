namespace IUR.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private IURDbContext dbContext;

        public IURDbContext Init()
        {
            return dbContext ?? (dbContext = new IURDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}