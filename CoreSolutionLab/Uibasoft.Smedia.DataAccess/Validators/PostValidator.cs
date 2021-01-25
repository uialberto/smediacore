﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Uibasoft.Smedia.Core.DTOs;
using Uibasoft.Smedia.Core.Entities;

namespace Uibasoft.Smedia.DataAccess.Validators
{
    public class PostValidator : AbstractValidator<PostDto>
    {
        public PostValidator()
        {

            RuleFor(post => post.Description)
                .NotNull()
                .WithMessage("La descripcion no puede ser nula.");


            RuleFor(post => post.Description)               
                .Length(10, 500)
                .WithMessage("La longitud de la Descripcion debe estar entre 10 y 500 caracteres.");

            RuleFor(post => post.Date)
               .NotNull()
               .LessThan(DateTime.Now);



        }       
    }
}
