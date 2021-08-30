using CollectionBoxWebApi.DataLayer.Entities;
using System.Collections.Generic;

namespace CollectionBoxWebApi.DataLayer.Repositories.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}
