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

namespace FS.Entity.EntityDefaults.Dtos
{
    public partial class EntityDefaultCreateDtoValidator : AbstractValidator<EntityDefaultCreateDto>
    {
        public EntityDefaultCreateDtoValidator()
        {
            RuleFor(p => p.EntityType)
                .NotNull()
                ;
            RuleFor(p => p.EntityId)
                .NotNull()
                ;
            RuleFor(p => p.DefaultType)
                .NotNull()
                ;
            CustomizeConfiguration();
        }
        partial void CustomizeConfiguration();
    }
    public partial class EntityDefaultUpdateDtoValidator : AbstractValidator<EntityDefaultUpdateDto>
    {
        public EntityDefaultUpdateDtoValidator()
        {
            RuleFor(p => p.EntityType)
                .NotNull()
                ;
            RuleFor(p => p.EntityId)
                .NotNull()
                ;
            RuleFor(p => p.DefaultType)
                .NotNull()
                ;
            CustomizeConfiguration();
        }
        partial void CustomizeConfiguration();
    }
}
