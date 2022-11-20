using Repository.Entities;

namespace Repository.Repositories.Generic
{
    public interface IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        TEntity Add(TEntity entity);
        List<TEntity> GetAll();
        TEntity? GetById(int id);
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}