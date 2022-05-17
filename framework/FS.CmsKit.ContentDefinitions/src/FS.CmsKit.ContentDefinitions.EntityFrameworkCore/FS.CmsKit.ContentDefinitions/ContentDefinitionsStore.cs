using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Services;
using FS.CmsKit.ContentDefinitionsMediator;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.TextTemplating;
using System.Linq;

namespace FS.CmsKit.ContentDefinitions
{
    public partial class ContentDefinitionsStore :
        MediatR.IRequestHandler<V1.CreateContentDefinition, ContentDefinition>,
        MediatR.IRequestHandler<V1.PatchContentPartDefinition, ContentPartDefinition>,
        MediatR.IRequestHandler<V1.PatchContentTypeDefinition, ContentTypeDefinition>
    {
        protected ITemplateDefinitionManager TemplateDefinitionManager => this.LazyServiceProvider.LazyGetRequiredService<ITemplateDefinitionManager>();
        private void check(ContentDefinition contentDefinition)
        {
            if (contentDefinition.IsPublish)
                throw new PublishedContentCantModifyException(contentDefinition.Version);
        }
        public async Task<ContentDefinition> Handle(V1.CreateContentDefinition request, CancellationToken cancellationToken)
        {
            var exist = await this.ContentDefinition.FindAsync(x => x.Version==request.Version);

            if (exist!=null)
                throw new DuplicateContentDefinitionVersionException(request.Version);

            var newEntity = new ContentDefinition(this.GuidGenerator.Create())
            {
                Version=request.Version
            };

            return newEntity;
        }

        public async Task<ContentPartDefinition> Handle(V1.PatchContentPartDefinition request, CancellationToken cancellationToken)
        {
            var contentDefinition = await this.ContentDefinition.GetAsync(request.ContentDefinitionId);

            check(contentDefinition);

            var templateDefinition = TemplateDefinitionManager.GetOrNull(request.TemplateDefinitionName);

            if (templateDefinition==null)
                throw new TemplateDefinitionNotExistException(request.TemplateDefinitionName);

            var result = await this.ContentPartDefinition.FindAsync(x => x.Name==request.Name) ??
                new ContentPartDefinition(GuidGenerator.Create());

            result.ContentDefinitionId=request.ContentDefinitionId;
            result.Name=request.Name;
            result.TemplateDefinitionName=request.TemplateDefinitionName;
            result.ContentPartFieldDefinitions.Clear();

            if (templateDefinition.Properties.ContainsKey("ModelType"))
            {
                var modelType = templateDefinition.Properties["ModelType"] as Type;

                result.Type=modelType.FullName;

                modelType.GetProperties().ToList().ForEach(x =>
                {
                    var field = result.ContentPartFieldDefinitions.GetOrAdd(y => y.Name==x.Name, () =>
                    {
                        return new ContentPartFieldDefinition(GuidGenerator.Create());
                    });
                    field.ContentPartDefinitionId=result.Id;
                    field.Name=x.Name;
                    field.Type=x.PropertyType.FullName;
                });
            }

            return result;
        }

        public async Task<ContentTypeDefinition> Handle(V1.PatchContentTypeDefinition request, CancellationToken cancellationToken)
        {

            var contentDefinition = await this.ContentDefinition.GetAsync(request.ContentDefinitionId);

            check(contentDefinition);

            var filter = new FS.Entity.EntityFeatures.EntityFeaturesAutoFilter(request.EntityType, request.EntityId);

            var contentTypeDefinition = filter.ApplyFilterTo(await this.ContentTypeDefinition.GetQueryableAsync()).Single();

            contentTypeDefinition.ContentDefinitionId=contentDefinition.Id;

            contentTypeDefinition.ContentTypePartDefinitions.Clear();

            request.ContentPartDefinitionIds.ForEach(x =>
            {
                var item = new FS.CmsKit.ContentDefinitions.ContentTypePartDefinition(GuidGenerator.Create())
                {
                    ContentTypeDefinitionId=contentTypeDefinition.Id,
                    ContentPartDefinitionId=x
                };
                contentTypeDefinition.ContentTypePartDefinitions.Add(item);
            });


            return contentTypeDefinition;
        }




    }
}
