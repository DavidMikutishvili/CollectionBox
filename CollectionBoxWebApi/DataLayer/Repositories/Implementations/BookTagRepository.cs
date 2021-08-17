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
    public class BookTagRepository : GenericRepository<BookTag>, IBookTagRepository
    {
        public BookTagRepository(DataContext context) : base(context)
        {
        }

        public void CreateTag(BookTag tag)
        {
            Create(tag);
        }

        public void DeleteTag(int id)
        {
            Delete(id);
        }

        public IEnumerable<BookTag> GetAllTags()
        {
            return GetAll();
        }

        public BookTag GetTagById(int id)
        {
            return GetById(id);
        }

        public void UpdateTag(BookTag tag)
        {
            Update(tag);
        }
    }
}
