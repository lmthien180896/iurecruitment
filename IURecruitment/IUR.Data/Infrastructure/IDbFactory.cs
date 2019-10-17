using System;

namespace IUR.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        IURDbContext Init();
    }
}