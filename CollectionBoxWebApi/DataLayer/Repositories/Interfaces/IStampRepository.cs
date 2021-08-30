using CollectionBoxWebApi.DataLayer.Entities;
using System.Collections.Generic;

namespace CollectionBoxWebApi.DataLayer.Repositories.Interfaces
{
    public interface IStampRepository
    {
        IEnumerable<Stamp> GetAllStamps();
        Stamp GetStampById(int id);
        void CreateStamp(Stamp stamp);
        void UpdateStamp(Stamp stamp);
        void DeleteStamp(int id);
    }
}
