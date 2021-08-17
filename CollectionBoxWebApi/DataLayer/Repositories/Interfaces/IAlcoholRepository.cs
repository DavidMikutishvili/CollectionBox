using CollectionBoxWebApi.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionBoxWebApi.DataLayer.Repositories.Interfaces
{
    public interface IAlcoholRepository
    {
        IEnumerable<Alcohol> GetAllAlcohol();
        Alcohol GetAlcoholById(int id);
        void CreateAlcohol(Alcohol alcohol);
        void UpdateAlcohol(Alcohol alcohol);
        void DeleteAlcohol(int id);
    }
}
