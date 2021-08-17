using CollectionBoxWebApi.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
