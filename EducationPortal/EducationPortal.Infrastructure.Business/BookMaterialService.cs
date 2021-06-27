using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using EFlecture.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Infrastructure.Business
{
    public class BookMaterialService : IBookMaterialService
    {
        private readonly IRepository<BookMaterial> bookMaterialRepository;

        public BookMaterialService(IRepository<BookMaterial> bookMaterialRepository)
        {
            this.bookMaterialRepository = bookMaterialRepository;
        }

        public async Task AddBookMaterial(BookMaterial bookMaterial)
        {
            await bookMaterialRepository.AddAsync(bookMaterial);
        }
    }
}
