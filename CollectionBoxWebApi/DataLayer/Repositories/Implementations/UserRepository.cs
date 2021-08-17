using CollectionBoxWebApi.DataLayer.Entities;
using CollectionBoxWebApi.DataLayer.GenericRepository;
using CollectionBoxWebApi.DataLayer.Helpers;

namespace CollectionBoxWebApi.DataLayer.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(DataContext context) : base(context)
        {
        }
    }
}
