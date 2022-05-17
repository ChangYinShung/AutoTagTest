using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Services;
using Volo.Abp.TextTemplating;

namespace FS.Abp.Emailing
{
    public partial class EmailingStore : DomainService
    {
        protected ITemplateDefinitionManager TemplateDefinitionManager => this.LazyServiceProvider.LazyGetRequiredService<ITemplateDefinitionManager>();
        public async Task<object> GetAsync(string no, string key)
        {
            var templateDefinition = TemplateDefinitionManager.GetOrNull(no);

            if (!templateDefinition.Properties.ContainsKey(no))
            {
                throw new TemplateNoDefinModelTypeException(no);
            }

            var type = templateDefinition.Properties["ModelType"] as Type;

            var cacheType = typeof(IDistributedCache<,>).MakeGenericType(type, typeof(string));

            var cache = this.LazyServiceProvider.LazyGetRequiredService(cacheType);

            var methods = cacheType.GetMethod("GetAsync");

            var task = (Task)methods.Invoke(cache, new object[] { key, null, false, default(CancellationToken) });

            await task.ConfigureAwait(false);

            var resultProperty = task.GetType().GetProperty("Result");

            return resultProperty.GetValue(task);
        }

        public async Task SetAsync(string no, string key, object item)
        {
            var templateDefinition = TemplateDefinitionManager.GetOrNull(no);

            var type = templateDefinition.Properties["ModelType"] as Type;

            if (type!=item.GetType())
                throw new ModelTypeNotMatchException(no, type.FullName, item.GetType().FullName);

            var cacheType = typeof(IDistributedCache<,>).MakeGenericType(type, typeof(string));

            var cache = this.LazyServiceProvider.LazyGetRequiredService(cacheType);

            var methods = cacheType.GetMethod("SetAsync");

            var task = (Task)methods.Invoke(cache, new object[] { key, item, null, null, false, default(CancellationToken) });

            await task.ConfigureAwait(false);
        }

    }
}
