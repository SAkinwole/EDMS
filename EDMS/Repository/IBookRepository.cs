using EDMS.Models;

namespace EDMS.Repository
{
    public interface IBookRepository
    {
        Task<int> AddNewDocument(DocumentViewModel model);
    }
}
