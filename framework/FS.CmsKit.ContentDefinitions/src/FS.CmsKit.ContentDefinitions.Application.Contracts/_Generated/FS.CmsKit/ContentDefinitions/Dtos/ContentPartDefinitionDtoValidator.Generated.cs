//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by YinChang.
// 5.1.3
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
using System.Reflection;
using FluentValidation;

namespace FS.CmsKit.ContentDefinitions.Dtos
{
    public partial class ContentPartDefinitionCreateDtoValidator : AbstractValidator<ContentPartDefinitionCreateDto>
    {
        public ContentPartDefinitionCreateDtoValidator()
        {
            RuleFor(p => p.ContentDefinitionId)
                ;
            RuleFor(p => p.Name)
                .NotNull()
                ;
            RuleFor(p => p.Type)
                .NotNull()
                ;
            RuleFor(p => p.TemplateDefinitionName)
                .NotNull()
                ;
            CustomizeConfiguration();
        }
        partial void CustomizeConfiguration();
    }
    public partial class ContentPartDefinitionUpdateDtoValidator : AbstractValidator<ContentPartDefinitionUpdateDto>
    {
        public ContentPartDefinitionUpdateDtoValidator()
        {
            RuleFor(p => p.ContentDefinitionId)
                ;
            RuleFor(p => p.Name)
                .NotNull()
                ;
            RuleFor(p => p.Type)
                .NotNull()
                ;
            RuleFor(p => p.TemplateDefinitionName)
                .NotNull()
                ;
            CustomizeConfiguration();
        }
        partial void CustomizeConfiguration();
    }
}
