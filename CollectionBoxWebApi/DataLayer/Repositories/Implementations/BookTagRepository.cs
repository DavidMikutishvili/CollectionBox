using CollectionBoxWebApi.DataLayer.Entities;
using CollectionBoxWebApi.DataLayer.GenericRepository;
using CollectionBoxWebApi.DataLayer.Repositories.Interfaces;
using System.Collections.Generic;

namespace CollectionBoxWebApi.DataLayer.Repositories
{
    public class BookTagRepository : GenericRepository<BookTag>, IBookTagRepository
    {
        public BookTagRepository(AppDbContext context) : base(context)
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
