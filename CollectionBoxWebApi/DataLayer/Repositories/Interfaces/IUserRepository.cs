using CollectionBoxWebApi.DataLayer.Authentication;
using System.Collections.Generic;

namespace CollectionBoxWebApi.DataLayer.Repositories.Interfaces
{
    public interface IUserRepository
    {
        ApplicationUser CreateUser(ApplicationUser user);
        ApplicationUser GetByEmail(string email);
        ApplicationUser GetById(string id);
        void DeleteAllUsers();
        IEnumerable<ApplicationUser> GetAllUsers();
    }
}
