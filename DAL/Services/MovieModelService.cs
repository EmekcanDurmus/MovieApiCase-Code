using DAL.Services.IService;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repositories.IRepository;

namespace DAL.Services
{
    public class MovieModelService : Services<MovieModel>, IMovieModelService
    {
        public MovieModelService(IUnitOfWork unitOfWork, IRepository<MovieModel> repository) : base(unitOfWork, repository)
        {
        }
    }
}
