using ExerciseTracker.App.Model;

namespace ExerciseTracker.App.Data.Repository;

public interface IRepository<TEntity> where TEntity : Entity
{
    ValueTask CreateAsync(TEntity entity, CancellationToken cancellationToken);
    ValueTask<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    ValueTask<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    ValueTask<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken);
    ValueTask<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
}