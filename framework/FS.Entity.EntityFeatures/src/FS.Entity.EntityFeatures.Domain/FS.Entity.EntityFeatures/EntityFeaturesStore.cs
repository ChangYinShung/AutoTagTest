using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace FS.Entity.EntityFeatures
{
    public class EntityFeaturesStore : Volo.Abp.Domain.Services.DomainService
    {
        private readonly IServiceProvider serviceProvider;

        public EntityFeaturesStore(
            IServiceProvider serviceProvider)
        {
            this.serviceProvider=serviceProvider;
        }
        private async Task<IEntity<Guid>> findAsync(Type e, LambdaExpression predicate, CancellationToken cancellationToken = default(CancellationToken))
        {
            var repositoryType = typeof(IRepository<>).MakeGenericType(e);

            var repository = serviceProvider.GetService(repositoryType);

            MethodInfo methodInfo = repositoryType.GetMethod("FindAsync");

            var task = (Task)methodInfo.Invoke(repository, new object[] { predicate, false, cancellationToken });

            await task.ConfigureAwait(false);

            var resultProperty = task.GetType().GetProperty("Result");

            return resultProperty.GetValue(task) as IEntity<Guid>;
        }

        public async Task<IEntity<Guid>> FindOwnerAsync(Type ownerType, Guid entityId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entityParameter = Expression.Parameter(ownerType, "e");

            var entityIdProperty = ownerType.GetProperty("Id", BindingFlags.Public | BindingFlags.Instance);

            var entityIdExp = Expression.Equal(
                        Expression.Property(entityParameter, entityIdProperty.Name),
                       Expression.Constant(entityId));

            var predicate = Expression.Lambda(entityIdExp, entityParameter);

            return await findAsync(ownerType, predicate, cancellationToken);
        }
        public async Task<IEntity<Guid>> FindFeatureAsync(Type featureType, string entityType, Guid entityId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entityParameter = Expression.Parameter(featureType, "e");

            var entityIdProperty = featureType.GetProperty("EntityId", BindingFlags.Public | BindingFlags.Instance);

            var entityTypeProperty = featureType.GetProperty("EntityType", BindingFlags.Public | BindingFlags.Instance);

            var entityIdExp = Expression.Equal(
                        Expression.Property(entityParameter, entityIdProperty.Name),
                        Expression.Call(Expression.Constant(entityId), typeof(object).GetMethod("ToString")));

            var entityTypeExp = Expression.Equal(
                        Expression.Property(entityParameter, entityTypeProperty.Name),
                        Expression.Constant(entityType));

            var predicate = Expression.Lambda(Expression.AndAlso(entityIdExp, entityTypeExp), entityParameter);

            return await findAsync(featureType, predicate, cancellationToken);
        }

        public async Task DeleteAsync(IEntity<Guid> toDeleteEntity)
        {
            var repositoryType = typeof(IBasicRepository<>).MakeGenericType(toDeleteEntity.GetType());

            var repository = serviceProvider.GetService(repositoryType);

            var methodInfo = repositoryType.GetMethod("DeleteAsync");

            var deleteTask = (Task)methodInfo.Invoke(repository, new object[] { toDeleteEntity, false, default(CancellationToken) });

            await deleteTask.ConfigureAwait(false);
        }

        public async Task<IEntity<Guid>> InsertAsync(IEntity<Guid> toInsertEntity)
        {
            var repositoryType = typeof(IBasicRepository<>).MakeGenericType(toInsertEntity.GetType());

            var repository = serviceProvider.GetService(repositoryType);

            MethodInfo methodInfo = repositoryType.GetMethod("InsertAsync");

            var task = (Task)methodInfo.Invoke(repository, new object[] { toInsertEntity, false, default(CancellationToken) });

            await task.ConfigureAwait(false);

            var resultProperty = task.GetType().GetProperty("Result");

            return resultProperty.GetValue(task) as IEntity<Guid>;
        }
    }
}
