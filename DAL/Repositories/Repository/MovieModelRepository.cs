using DAL.Repositories.IRepository;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Repository
{
    public class MovieModelRepository : Repository<MovieModel>, IMovieModel
    {
        private ApplicationDbContext _context;
        public MovieModelRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
