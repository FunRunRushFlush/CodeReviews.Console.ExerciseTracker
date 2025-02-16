using ExerciseTracker.App.Model;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.App.Data.Repository;

public sealed partial class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly IDbContextFactory<ExerciseDbContext> _dbContextFactory;

    public Repository(IDbContextFactory<ExerciseDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }


    public async ValueTask<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        var result = await dbContext.Set<TEntity>().ToListAsync(cancellationToken);
        return result;
    }

    public async ValueTask<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        var result = await dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
        return result;
    }

    public async ValueTask CreateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        await dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async ValueTask<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        var result = await dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == entity.Id, cancellationToken: cancellationToken);
        if (result != null)
        {
            dbContext.Entry(result).CurrentValues.SetValues(entity);
            await dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        return false;
    }

    public async ValueTask<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        var result = await dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
        if (result != null)
        {
            dbContext.Set<TEntity>().Remove(result);
            await dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        return false;
    }
}