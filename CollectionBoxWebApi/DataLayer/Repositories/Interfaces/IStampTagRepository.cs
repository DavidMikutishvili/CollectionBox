using CollectionBoxWebApi.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionBoxWebApi.DataLayer.Repositories.Interfaces
{
    public interface IStampTagRepository
    {
        IEnumerable<StampTag> GetAllTags();
        StampTag GetTagById(int id);
        void CreateTag(StampTag tag);
        void UpdateTag(StampTag tag);
        void DeleteTag(int id);
    }
}
