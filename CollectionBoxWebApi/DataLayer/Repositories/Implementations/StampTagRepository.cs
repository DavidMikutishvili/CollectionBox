using CollectionBoxWebApi.DataLayer.Entities;
using CollectionBoxWebApi.DataLayer.GenericRepository;
using CollectionBoxWebApi.DataLayer.Repositories.Interfaces;
using System.Collections.Generic;

namespace CollectionBoxWebApi.DataLayer.Repositories
{
    public class StampTagRepository : GenericRepository<StampTag>, IStampTagRepository
    {
        public StampTagRepository(AppDbContext context) : base(context)
        {
        }

        public void CreateTag(StampTag tag)
        {
            Create(tag);
        }

        public void DeleteTag(int id)
        {
            Delete(id);
        }

        public IEnumerable<StampTag> GetAllTags()
        {
            return GetAll();
        }

        public StampTag GetTagById(int id)
        {
            return GetById(id);
        }

        public void UpdateTag(StampTag tag)
        {
            Update(tag);
        }
    }
}
