using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly IAppDBContext _context;
        public UserRepository(IAppDBContext context)
        {
            _context = context;
        }
        public UserProfile AddUserProfile(UserProfile userProfile)
        {
            _context.Set<UserProfile>().Add(userProfile);
            _context.SaveChanges();
            return userProfile;
        }

        public IQueryable<UserProfile> GetAllUsers(bool isActive = true)
        {
            var list=_context
                .Set<UserProfile>()
                .Where(up=>up.IsActive || up.IsActive==isActive)
                .AsQueryable();
            return list;
        }
    }
}
