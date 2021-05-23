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
        private static readonly IMaterialService materialService = CustomServiceProvider.Provider.GetRequiredService<IMaterialService>();
        public VideoMaterialValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Must(UniqueMaterial).WithMessage("Video name already taken");
            RuleFor(x => x.Quality).NotNull();
            RuleFor(x => x.Duration).NotEmpty();
        }
        private bool UniqueMaterial(string uniqeItem)
        {
            if (materialService.GetVideoMaterials().Any(x => x.Name.ToLower() == uniqeItem.ToLower()))
            {
                return false;
            }
            return true;
        }
    }
}
