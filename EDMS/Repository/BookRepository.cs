using EDMS.Data;
using EDMS.Models;

namespace EDMS.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewDocument(DocumentViewModel model)
        {
            var newDoc = new Document()
            {
                Title = model.Title,
                Description = model.Description,
                DateUpdated = model.DateUpdated,
                DateUploaded = model.DateUploaded,
                FileUrl = model.FileUrl
            };

            await _context.Documents.AddAsync(newDoc);
            await _context.SaveChangesAsync();

            return newDoc.Id;
        }

    }
}
