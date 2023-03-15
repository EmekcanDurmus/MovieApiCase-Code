using DAL.Repositories.IRepository;
using DAL.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class Services<T> : IService<T> where T : class
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<T> _repository;
        public Services(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public bool Delete(int id)
        {
            _repository.Delete(id);
            _unitOfWork.Save();
            return true;
        }

        public T Edit(T entity)
        {
            var newEntity = _repository.Edit(entity);
            _unitOfWork.Save();
            return newEntity;
        }

        public async Task<T> Get(int id)
        {
           return await _repository.Get(id);
        }

        public async Task<ICollection<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            return await _repository.GetAll(filter, orderBy, includeProperties);
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            return await _repository.GetFirstOrDefault(filter, includeProperties);
        }

        public async Task<bool> Insert(T entity)
        {
            await _repository.Insert(entity);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
