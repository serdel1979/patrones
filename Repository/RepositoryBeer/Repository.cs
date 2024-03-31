using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryBeer
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly PatternsContext _patternsContext;

        private DbSet<TEntity> _dbSet;

        public Repository(PatternsContext patternsContext)
        {
            _patternsContext = patternsContext;
            _dbSet = _patternsContext.Set<TEntity>();
        }

        public void Add(TEntity data) => _dbSet.Add(data);

        public void Delete(long Id)
        {
            var entity = _dbSet.Find(Id);
            _dbSet.Remove(entity);
        }

        public IEnumerable<TEntity> Get() => _dbSet.ToList();

        public TEntity Get(int id) => _dbSet.Find(id);

        public void Update(TEntity data)
        {
            _dbSet.Attach(data);
            _patternsContext.Entry(data).State = EntityState.Modified;
        }

        public void Save()
        {
            _patternsContext.SaveChanges();
        }

    }
}
