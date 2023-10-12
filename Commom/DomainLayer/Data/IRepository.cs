using System.Linq.Expressions;

namespace CarRare.Commom.DomainLayer.Data
{
    public interface IRepository<TEntity, TIdType>
        where TEntity : class
        where TIdType : struct
    {
        Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
        Task<TEntity> GetByIdAsync(TIdType id, CancellationToken cancellationToken = default);
        Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(TIdType id, CancellationToken cancellationToken = default);
    }
}
