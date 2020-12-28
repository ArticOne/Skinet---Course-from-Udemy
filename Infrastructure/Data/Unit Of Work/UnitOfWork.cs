using Core.Interfaces;
using Core.Model;
using Infrastructure.Data.Contexts;
using Infrastructure.Data.Repos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Unit_Of_Work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _context;
        private Hashtable _repositories;

        public UnitOfWork(StoreContext _context)
        {
            this._context = _context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }


        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<TEntity> )_repositories[type];
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
