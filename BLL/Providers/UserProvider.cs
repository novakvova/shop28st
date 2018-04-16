using BLL.Abstract;
using BLL.Services.Identity;
using BLL.ViewModels;
using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserRepository _userReposittory;
        private readonly ApplicationUserManager _userManager;
        public UserProvider(IUserRepository userRepository,
            ApplicationUserManager userManager)
        {
            _userReposittory = userRepository;
            _userManager = userManager;
        }
        private ApplicationUserManager UserManager
        {
            get
            {
                return _userManager;
            }
        }
        public List<UserViewModel> GetUsers(bool isActive = true)
        {
            var listUsers=_userReposittory
                .GetAllUsers(isActive)
                .Select(u=>new UserViewModel
                {
                    Id=u.Id,
                    Email=u.ApplicationUser.Email,
                    Image=u.Image,
                    Name=u.ApplicationUser.UserName,
                    Phone=u.Phone
                }).ToList();
            return listUsers;
        }
    }
}
