using FluentValidation;
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
                .Length(10, 15);


            RuleFor(post => post.Date)
               .NotNull()
               .LessThan(DateTime.Now);



        }       
    }
}
