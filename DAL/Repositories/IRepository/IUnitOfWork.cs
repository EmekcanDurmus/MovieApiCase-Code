using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieModel MovieModel { get; }
        IUserRepository User { get; }

        Task SaveAsync();
        void Save();
    }
}
