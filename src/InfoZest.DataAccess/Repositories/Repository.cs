using InfoZest.DataAccess.Contexts;
using InfoZest.DataAccess.IRepositories;
using InfoZest.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InfoZest.DataAccess.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly DbSet<TEntity> table;
    public Repository(AppDbContext context)
    {
        this.table = context.Set<TEntity>();
    }

    public async ValueTask<TEntity> InsertAsync(TEntity entity)
    {
        await this.table.AddAsync(entity);
        return entity;
    }

    public void Update(TEntity entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        this.table.Update(entity).State = EntityState.Modified;
    }

    public void Delete(TEntity entity)
    {
        entity.IsDeleted = true;
        this.table.Update(entity).State = EntityState.Modified;
    }

    public void Destroy(TEntity entity)
    {
        this.table.Remove(entity);
    }

    public async ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null!)
    {
        IQueryable<TEntity> entities = expression == null! ? this.table.AsQueryable() : this.table.Where(expression).AsQueryable();

        if (includes is not null)
            foreach (var include in includes)
                entities = entities.Include(include);

        return await entities.FirstOrDefaultAsync();
    }

    public IQueryable<TEntity> SelectAll(
        Expression<Func<TEntity, bool>> expression = null!, string[] includes = null!, bool isTracking = true)
    {
        IQueryable<TEntity> entities = expression == null! ? this.table.AsQueryable()
            : this.table.Where(expression).AsQueryable();

        entities = isTracking ? entities.AsNoTracking() : entities;

        if (includes is not null)
            foreach (var include in includes)
                entities = entities.Include(include);

        return entities;
    }
}