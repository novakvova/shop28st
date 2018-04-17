using BLL.Abstract;
using BLL.Services.Identity;
using BLL.ViewModels;
using DAL.Abstract;
using DAL.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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

        public int Create(UserCreateViewModel userCreate, string path)
        {
            try
            {
                var dubEmail = UserManager.FindByEmail(userCreate.Email);
                if (dubEmail != null)
                {
                    return 0;
                }
                var user = new ApplicationUser
                {
                    UserName = userCreate.Email,
                    Email = userCreate.Email
                };
                var result = UserManager.Create(user, userCreate.Password);
                if (result.Succeeded)
                {
                    var image = Guid.NewGuid().ToString()+".jpg";
                    string savepath = path + image;
                    Bitmap imageBig = Healpers.ImageWorker
                        .CreateImage(userCreate.Image, 400, 600);
                    imageBig.Save(savepath, ImageFormat.Jpeg);
                    UserProfile userProfile = new UserProfile
                    {
                        Id = user.Id,
                        IsActive = true,
                        Phone = userCreate.Phone,
                        Image=image
                    };
                    _userReposittory.AddUserProfile(userProfile);
                    return userProfile.Id;
                }
            }
            catch { }
            return 0;
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
