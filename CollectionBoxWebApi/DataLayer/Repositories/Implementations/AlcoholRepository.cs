using CollectionBoxWebApi.DataLayer.Entities;
using CollectionBoxWebApi.DataLayer.GenericRepository;
using CollectionBoxWebApi.DataLayer.Helpers;
using CollectionBoxWebApi.DataLayer.Repositories.Interfaces;
using System.Collections.Generic;

namespace CollectionBoxWebApi.DataLayer.Repositories
{
    public class AlcoholRepository : GenericRepository<Alcohol>, IAlcoholRepository
    {
        public AlcoholRepository(DataDbContext context) : base(context)
        {
        }

        public void CreateAlcohol(Alcohol alcohol)
        {
            Create(alcohol);
        }

        public void DeleteAlcohol(int id)
        {
            Delete(id);
        }

        public Alcohol GetAlcoholById(int id)
        {
            return GetById(id);
        }

        public IEnumerable<Alcohol> GetAllAlcohol()
        {
            return GetAll();
        }

        public void UpdateAlcohol(Alcohol alcohol)
        {
            Update(alcohol);
        }
    }
}
