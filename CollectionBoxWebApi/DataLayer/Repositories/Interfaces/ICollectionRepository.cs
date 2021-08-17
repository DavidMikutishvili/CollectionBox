using CollectionBoxWebApi.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
