using EducationPortal.Automapper;
using EducationPortal.Domain.Core;
using EducationPortal.FluentValidationModels;
using EducationPortal.Helpers;
using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Controllers
{
    public class VideoMaterialController
    {
        readonly IVideoMaterialService videoMaterialService;

        readonly VideoMaterialValidator videoValidator = new VideoMaterialValidator();
        readonly MaterialHelper materialHelper = new MaterialHelper();
        readonly MaterialValidator validations = new MaterialValidator();
        private readonly IMapper mapper;

        public VideoMaterialController(IVideoMaterialService videoMaterialService, IMapper mapper)
        {
            this.videoMaterialService = videoMaterialService;
            this.mapper = mapper;
        }

        public VideoMaterialVM VideoCreate()
        {
            var videoVM = materialHelper.VideoFullData();
            if (validations.Validate(videoVM).IsValid && videoValidator.Validate(videoVM).IsValid)
            {
                var mappedVideo = mapper.Map<VideoMaterialVM, VideoMaterial>(videoVM);
                videoMaterialService.AddVideoMaterial(mappedVideo);
                Dye.Succsess();
                Console.WriteLine("You have add video");
                Console.ResetColor();
                return videoVM;
            }
            else
            {
                Dye.Fail();
                Console.WriteLine(videoValidator.Validate(videoVM) + " " + " " + validations.Validate(videoVM));
                Console.ResetColor();
                VideoCreate();
                return null;
            }
        }
    }
}
