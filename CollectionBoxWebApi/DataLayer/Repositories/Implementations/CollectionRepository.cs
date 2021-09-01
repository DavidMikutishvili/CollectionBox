using CollectionBoxWebApi.DataLayer.Entities;
using CollectionBoxWebApi.DataLayer.GenericRepository;
using System.Collections.Generic;

namespace CollectionBoxWebApi.DataLayer.Repositories
{
    public class CollectionRepository : GenericRepository<CollectionGallery>, 
                                        ICollectionRepository
    {
        public CollectionRepository(AppDbContext context) : base(context)
        {
        }

        public void CreateCollection(CollectionGallery collection)
        {
            Create(collection);
        }

        public void DeleteCollection(int id)
        {
            Delete(id);
        }

        public IEnumerable<CollectionGallery> GetAllCollections()
        {
            return GetAll();
        }

        public CollectionGallery GetCollectionById(int id)
        {
            return GetById(id);
        }

        public void UpdateCollection(CollectionGallery collection)
        {
            Update(collection);
        }
    }
}
