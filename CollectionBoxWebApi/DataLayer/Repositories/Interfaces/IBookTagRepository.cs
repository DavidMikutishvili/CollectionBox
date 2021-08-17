using CollectionBoxWebApi.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionBoxWebApi.DataLayer.Repositories.Interfaces
{
    public interface IBookTagRepository
    {
        IEnumerable<BookTag> GetAllTags();
        BookTag GetTagById(int id);
        void CreateTag(BookTag tag);
        void UpdateTag(BookTag tag);
        void DeleteTag(int id);
    }
}
