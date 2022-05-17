﻿//------------------------------------------------------------------------------
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
    public partial class EntityDefaultItemCreateDtoValidator : AbstractValidator<EntityDefaultItemCreateDto>
    {
        public EntityDefaultItemCreateDtoValidator()
        {
            RuleFor(p => p.EntityProperties)
                ;
            RuleFor(p => p.EntityDefaultId)
                .NotNull()
                ;
            CustomizeConfiguration();
        }
        partial void CustomizeConfiguration();
    }
    public partial class EntityDefaultItemUpdateDtoValidator : AbstractValidator<EntityDefaultItemUpdateDto>
    {
        public EntityDefaultItemUpdateDtoValidator()
        {
            RuleFor(p => p.EntityProperties)
                ;
            RuleFor(p => p.EntityDefaultId)
                .NotNull()
                ;
            CustomizeConfiguration();
        }
        partial void CustomizeConfiguration();
    }
}
