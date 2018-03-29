using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Application.Extensions
{
    public static class RepositoryExtensions
    {
        public static TEntity InsertWithId<TEntity>(this IRepository<TEntity, long> repository, TEntity newEntity)
                    where TEntity : class, IEntity<long>

        {
            var id = repository.InsertAndGetId(newEntity);
            newEntity.Id = id;
            return newEntity;
        }
    }
}
