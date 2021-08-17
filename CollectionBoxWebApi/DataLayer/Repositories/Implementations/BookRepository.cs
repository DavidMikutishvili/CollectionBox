using CollectionBoxWebApi.DataLayer.Entities;
using CollectionBoxWebApi.DataLayer.GenericRepository;
using CollectionBoxWebApi.DataLayer.Helpers;
using CollectionBoxWebApi.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionBoxWebApi.DataLayer.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
                                    
    {
        public BookRepository(DataContext context) : base(context)
        {
        }

        public void CreateBook(Book book)
        {
            Create(book);
        }

        public void DeleteBook(int id)
        {
            Delete(id);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return GetAll();
        }

        public Book GetBookById(int id)
        {
            return GetById(id);
        }

        public void UpdateBook(Book book)
        {
            Update(book);
        }
    }
}
