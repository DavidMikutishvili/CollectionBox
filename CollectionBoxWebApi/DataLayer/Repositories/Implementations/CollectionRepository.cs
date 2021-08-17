using CollectionBoxWebApi.DataLayer.Entities;
using CollectionBoxWebApi.DataLayer.GenericRepository;
using CollectionBoxWebApi.DataLayer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionBoxWebApi.DataLayer.Repositories
{
    public class CollectionRepository : GenericRepository<CollectionGallery>, 
                                        ICollectionRepository
    {
        public CollectionRepository(DataContext context) : base(context)
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
