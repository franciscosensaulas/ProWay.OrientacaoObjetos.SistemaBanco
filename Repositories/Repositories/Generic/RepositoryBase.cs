using Microsoft.EntityFrameworkCore;
using Repository.Database;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Generic
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        protected readonly ProjetoContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(ProjetoContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public virtual TEntity Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public virtual TEntity? GetById(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public virtual List<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}
