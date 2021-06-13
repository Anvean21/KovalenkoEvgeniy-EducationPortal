using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationPortal.Infrastructure.Business
{
    public class BookMaterialService : IBookMaterialService
    {
        private readonly IRepository<BookMaterial> bookMaterialRepository;

        public BookMaterialService(IRepository<BookMaterial> bookMaterialRepository)
        {
            this.bookMaterialRepository = bookMaterialRepository;
        }

        public void AddBookMaterial(BookMaterial bookMaterial)
        {
            bookMaterialRepository.Create(bookMaterial);
        }

        public BookMaterial GetBookMaterialByName(string name)
        {
            return bookMaterialRepository.GetAsync(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }

        public IEnumerable<BookMaterial> GetBookMaterials()
        {
            return bookMaterialRepository.GetAsync();
        }
    }
}
