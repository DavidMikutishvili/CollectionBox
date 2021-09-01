using CollectionBoxWebApi.DataLayer.Entities;
using CollectionBoxWebApi.DataLayer.GenericRepository;
using CollectionBoxWebApi.DataLayer.Repositories.Interfaces;
using System.Collections.Generic;

namespace CollectionBoxWebApi.DataLayer.Repositories
{
    public class StampRepository : GenericRepository<Stamp>, IStampRepository
    {
        public StampRepository(AppDbContext context) : base(context)
        {
        }

        public void CreateStamp(Stamp stamp)
        {
            Create(stamp);
        }

        public void DeleteStamp(int id)
        {
            Delete(id);
        }

        public IEnumerable<Stamp> GetAllStamps()
        {
            return GetAll();
        }

        public Stamp GetStampById(int id)
        {
            return GetById(id);
        }

        public void UpdateStamp(Stamp stamp)
        {
            Update(stamp);
        }
    }
}
