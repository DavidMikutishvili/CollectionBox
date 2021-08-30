using CollectionBoxWebApi.DataLayer.Entities;
using System.Collections.Generic;

namespace CollectionBoxWebApi.DataLayer.Repositories
{
    public interface ICollectionRepository
    {
        IEnumerable<CollectionGallery> GetAllCollections();
        CollectionGallery GetCollectionById(int id);
        void CreateCollection(CollectionGallery collection);
        void UpdateCollection(CollectionGallery collection);
        void DeleteCollection(int id);
    }
}
