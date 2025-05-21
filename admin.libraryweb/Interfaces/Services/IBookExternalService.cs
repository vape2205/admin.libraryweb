using admin.libraryweb.Models.ExternalServices.Library;

namespace admin.libraryweb.Interfaces.Services
{
    public interface IBookExternalService
    {
        Task<BookModel> GetById(Guid id);
        Task<IEnumerable<BookModel>> GetAll(int pageNumber = 1, int pageSize = 10);
        Task<IEnumerable<BookModel>> FindByTitle(string queryString, int pageNumber = 1, int pageSize = 10);
        Task<IEnumerable<BookModel>> FindByAuthor(string queryString, int pageNumber = 1, int pageSize = 10);
        Task<BookModel> Crear(CreateBookCommand model);
        Task Eliminar(Guid id);
    }
}
