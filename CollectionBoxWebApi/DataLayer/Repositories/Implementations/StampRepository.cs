using CollectionBoxWebApi.DataLayer.Entities;
using CollectionBoxWebApi.DataLayer.GenericRepository;
using CollectionBoxWebApi.DataLayer.Helpers;
using CollectionBoxWebApi.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionBoxWebApi.DataLayer.Repositories
{
    public class StampRepository : GenericRepository<Stamp>, IStampRepository
    {
        public StampRepository(DataContext context) : base(context)
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
