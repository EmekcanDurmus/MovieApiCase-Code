using DAL.Repositories.IRepository;
using Microsoft.Extensions.Options;
using SharedTools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IOptions<AppSettings> _appsettings;

        public UnitOfWork(ApplicationDbContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appsettings = appSettings;
        }

        public IMovieModel MovieModel => new MovieModelRepository(_context);
        public IUserRepository User => new UserRepository(_context, _appsettings);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
