using EducationPortal.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.FluentValidationModels
{
    public class VideoMaterialValidator : AbstractValidator<VideoMaterialVM>
    {
        public VideoMaterialValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Path).NotEmpty();
            RuleFor(x => x.Quality).NotEmpty();
            RuleFor(x => x.Duration).NotEmpty();
        }
    }
}
