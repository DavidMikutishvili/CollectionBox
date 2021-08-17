using CollectionBoxWebApi.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionBoxWebApi.DataLayer.Repositories.Interfaces
{
    public interface IAlcoholTagRepository
    {
        IEnumerable<AlcoholTag> GetAllTags();
        AlcoholTag GetTagById(int id);
        void CreateTag(AlcoholTag tag);
        void UpdateTag(AlcoholTag tag);
        void DeleteTag(int id);
    }
}
