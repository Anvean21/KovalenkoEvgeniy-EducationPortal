using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationPortal.FluentValidationModels
{
    public class VideoMaterialValidator : AbstractValidator<VideoMaterialVM>
    {
        public VideoMaterialValidator()
        {
            RuleFor(x => x.Quality).NotNull();
            RuleFor(x => x.Duration).NotEmpty();
        }
    }
}
