using CollectionBoxWebApi.DataLayer.Authentication;
using CollectionBoxWebApi.DataLayer.GenericRepository;
using CollectionBoxWebApi.DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CollectionBoxWebApi.DataLayer.Repositories.Implementations
{
    public class UserRepository : GenericRepository<ApplicationUser>,
                                  IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<ApplicationUser> _table;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _table = _context.Set<ApplicationUser>();
        }

        public ApplicationUser CreateUser(ApplicationUser user)
        {
            _table.Add(user);
            _context.SaveChanges();
            //user.Id =_context.SaveChanges(); - ?

            return user;
        }

        public void DeleteAllUsers()
        {
            _table.RemoveRange(_table);
            _context.SaveChanges();
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return GetAll();
        }

        public ApplicationUser GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public ApplicationUser GetById(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
