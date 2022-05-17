using System;
using System.Collections.Generic;
using System.Text;

namespace FS.CmsKit.ContentDefinitionsMediator
{
    public static partial class V1
    {
        public class CreateContentDefinition : MediatR.IRequest<ContentDefinitions.ContentDefinition>, FS.Abp.MediatR.ICommand
        {
            public string Version { get; set; }
        }

        public class PatchContentPartDefinition : MediatR.IRequest<ContentDefinitions.ContentPartDefinition>, FS.Abp.MediatR.ICommand
        {
            public Guid ContentDefinitionId { get; set; }

            public virtual string Name { get; set; }

            public virtual string Type { get; set; }

            public virtual string TemplateDefinitionName { get; set; }
        }

        public class PatchContentTypeDefinition : MediatR.IRequest<ContentDefinitions.ContentTypeDefinition>, FS.Abp.MediatR.ICommand
        {
            public Guid ContentDefinitionId { get; set; }

            public virtual string EntityType { get; set; }

            public virtual string EntityId { get; set; }

            public virtual List<Guid> ContentPartDefinitionIds { get; set; }
        }


    }

}
