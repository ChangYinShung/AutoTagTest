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

namespace FS.CmsKit.EntityMedias.Dtos
{
    public partial class EntityMediaCreateDtoValidator : AbstractValidator<EntityMediaCreateDto>
    {
        public EntityMediaCreateDtoValidator()
        {
            RuleFor(p => p.EntityType)
                .Length(0, 64)
                .NotNull()
                ;
            CustomizeConfiguration();
        }
        partial void CustomizeConfiguration();
    }
    public partial class EntityMediaUpdateDtoValidator : AbstractValidator<EntityMediaUpdateDto>
    {
        public EntityMediaUpdateDtoValidator()
        {
            RuleFor(p => p.EntityType)
                .Length(0, 64)
                .NotNull()
                ;
            CustomizeConfiguration();
        }
        partial void CustomizeConfiguration();
    }
}
