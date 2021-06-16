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
    public class BookMaterialController
    {
        readonly IBookMaterialService bookMaterialService;
        private readonly IMapper mapper;

        readonly BookMaterialValidator bookValidator = new BookMaterialValidator();
        readonly MaterialValidator validations = new MaterialValidator();

        readonly MaterialHelper materialHelper = new MaterialHelper();

        public BookMaterialController(IBookMaterialService bookMaterialService, IMapper mapper)
        {
            this.bookMaterialService = bookMaterialService;
            this.mapper = mapper;
        }

        public BookMaterialVM BookCreate()
        {
            var bookVM = materialHelper.BookFullData();
            if (validations.Validate(bookVM).IsValid && bookValidator.Validate(bookVM).IsValid)
            {
                bookMaterialService.AddBookMaterial(mapper.Map<BookMaterialVM, BookMaterial>(bookVM));
                Dye.Succsess();
                Console.WriteLine("You have add book");
                Console.ResetColor();

                return bookVM;
            }
            else
            {
                Dye.Fail();
                Console.WriteLine(bookValidator.Validate(bookVM) + " " + " " + validations.Validate(bookVM));
                Console.ResetColor();

                return null;
            }
        }

        public BookMaterialVM GetBookMaterialByName(string name)
        {
            return mapper.Map<BookMaterial, BookMaterialVM>(bookMaterialService.GetBookMaterialByName(name));
        }

        public IEnumerable<BookMaterial> GetBookMaterials()
        {
            return bookMaterialService.GetBookMaterials();
        }
    }
}
