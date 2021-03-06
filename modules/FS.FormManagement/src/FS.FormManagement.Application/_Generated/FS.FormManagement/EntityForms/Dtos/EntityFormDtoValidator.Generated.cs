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

namespace FS.FormManagement.EntityForms.Dtos
{
    public partial class EntityFormCreateDtoValidator : AbstractValidator<EntityFormCreateDto>
    {
        public EntityFormCreateDtoValidator()
        {
            RuleFor(p => p.EntityType)
                .Length(0, 64)
                .NotNull()
                ;
            RuleFor(p => p.EntityId)
                .Length(0, 64)
                .NotNull()
                ;
            RuleFor(p => p.FormId)
                .NotNull()
                ;
            CustomizeConfiguration();
        }
        partial void CustomizeConfiguration();
    }
    public partial class EntityFormUpdateDtoValidator : AbstractValidator<EntityFormUpdateDto>
    {
        public EntityFormUpdateDtoValidator()
        {
            RuleFor(p => p.EntityType)
                .Length(0, 64)
                .NotNull()
                ;
            RuleFor(p => p.EntityId)
                .Length(0, 64)
                .NotNull()
                ;
            RuleFor(p => p.FormId)
                .NotNull()
                ;
            CustomizeConfiguration();
        }
        partial void CustomizeConfiguration();
    }
}
