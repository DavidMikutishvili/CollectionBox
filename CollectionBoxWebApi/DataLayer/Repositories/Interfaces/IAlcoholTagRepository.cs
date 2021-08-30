using CollectionBoxWebApi.DataLayer.Entities;
using System.Collections.Generic;

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
