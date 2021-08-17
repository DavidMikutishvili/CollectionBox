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
        private DataContext _context; 
        private DbSet<T> _table;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public void Create(T item)
        {
            _table.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)  // todo: save
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetById(int id)
        {
            return _table.Find(id);
        }

        public void Update(T item) // todo: save
        {
            _table.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
