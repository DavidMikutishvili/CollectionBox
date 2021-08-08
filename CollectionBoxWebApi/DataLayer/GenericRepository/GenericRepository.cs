using CollectionBoxWebApi.DataLayer.Helpers;
using CollectionBoxWebApi.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionBoxWebApi.DataLayer.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        private DataContext _context = null; // null is needed ?
        private DbSet<T> _table = null; // null is needed ?

        public GenericRepository()
        {
            _context = new DataContext();
            _table = _context.Set<T>();
        }

        public GenericRepository(DataContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public void Create(T item)
        {
            _table.Add(item);
            _context.SaveChanges();
            //_context.Users.Add(item);
            //_context.SaveChanges();
        }

        public void Delete(int id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetById(int id)
        {
            return _table.Find(id);
        }

        public void Save() // ???
        {
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            _table.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
