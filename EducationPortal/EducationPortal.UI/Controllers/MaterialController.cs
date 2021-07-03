using EducationPortal.Domain.Core;
using EducationPortal.Services.Interfaces;
using EducationPortal.UI.Automapper;
using EducationPortal.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.UI.Controllers
{
    [Authorize]

    public class MaterialController : Controller
    {
        private readonly ILogger<MaterialController> logger;
        private readonly IMaterialService materialService;
        private readonly IVideoMaterialService videoMaterialService;
        private readonly IBookMaterialService bookMaterialService;
        private readonly IArticleMaterialService articleMaterialService;
        private readonly IMapper mapper;

        public MaterialController(ILogger<MaterialController> logger, IMaterialService materialService, IVideoMaterialService videoMaterialService, IBookMaterialService bookMaterialService, IArticleMaterialService articleMaterialService, IMapper mapper)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.materialService = materialService;
            this.bookMaterialService = bookMaterialService;
            this.videoMaterialService = videoMaterialService;
            this.articleMaterialService = articleMaterialService;
        }

        [HttpGet]
        public IActionResult MaterialList()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateVideo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVideo(VideoMaterialVM videoMaterialVM)
        {
            if (!ModelState.IsValid && materialService.UniqueMaterialName(videoMaterialVM.Name))
            {
                return View("CreateVideo", videoMaterialVM);
            }

            var mappedVideo = mapper.Map<VideoMaterialVM, VideoMaterial>(videoMaterialVM);

            await videoMaterialService.AddVideoMaterial(mappedVideo);
            return RedirectToAction("MaterialList", "Material");
        }

        [HttpGet]
        public IActionResult CreateArticle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(ArticleMaterialVM articleMaterialVM)
        {
            if (!ModelState.IsValid && materialService.UniqueMaterialName(articleMaterialVM.Name))
            {
                return View("CreateArticle", articleMaterialVM);
            }

            var mappedArticle = mapper.Map<ArticleMaterialVM, ArticleMaterial>(articleMaterialVM);

            await articleMaterialService.AddArticleMaterial(mappedArticle); 
            return RedirectToAction("MaterialList", "Material");

        }

        [HttpGet]
        public IActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(BookMaterialVM bookMaterialVM)
        {
            if (!ModelState.IsValid && materialService.UniqueMaterialName(bookMaterialVM.Name))
            {
                return View("CreateBook", bookMaterialVM);
            }

            var mappedBook = mapper.Map<BookMaterialVM, BookMaterial>(bookMaterialVM);

            await bookMaterialService.AddBookMaterial(mappedBook);
            return RedirectToAction("MaterialList", "Material");
        }
    }
}
