using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace SixMan.ChiMa.EFCore.Repositories
{
    /// <summary>
    /// Base class for custom repositories of the application.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key type of the entity</typeparam>
    public abstract class ChiMaRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<ChiMaDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected ChiMaRepositoryBase(IDbContextProvider<ChiMaDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        // Add your common methods for all repositories
    }

    /// <summary>
    /// Base class for custom repositories of the application.
    /// This is a shortcut of <see cref="ChiMaRepositoryBase{TEntity,TPrimaryKey}"/> for <see cref="int"/> primary key.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public abstract class ChiMaRepositoryBase<TEntity> : ChiMaRepositoryBase<TEntity, long>
        where TEntity : class, IEntity<long>
    {
        protected ChiMaRepositoryBase(IDbContextProvider<ChiMaDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        // Do not add any method here, add to the class above (since this inherits it)!!!
    }
}
