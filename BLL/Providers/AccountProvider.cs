using BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ViewModels.Identity;
using DAL.Entities;
using DAL.Abstract;
using BLL.Services.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace BLL.Providers
{
    public class AccountProvider : IAccountProvider
    {
        private readonly IUserRepository _userReposittory;
        private readonly ApplicationUserManager _userManager;
        private readonly IAuthenticationManager _authManager;
        private readonly ApplicationSignInManager _singInManager;

        public AccountProvider(IUserRepository userRepository,
            ApplicationUserManager userManager,
            IAuthenticationManager authManager,
            ApplicationSignInManager singInManager)
        {
            _userReposittory = userRepository;
            _userManager = userManager;
            _authManager = authManager;
            _singInManager = singInManager;
        }
        private ApplicationSignInManager SignInManager
        {
            get
            {
                return _singInManager;
            }
        }
        private ApplicationUserManager UserManager
        {
            get
            {
                return _userManager;
            }
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return _authManager;
            }
        }

        public UserStatus Login(LoginViewModel model)
        {
            var result=SignInManager
                .PasswordSignIn(model.Email, model.Password, 
                model.RememberMe, shouldLockout: false);
            if(result==SignInStatus.Success)
            {
                return UserStatus.Success;
            }
            return UserStatus.Error;
        }

        public void LogOff()
        {
            AuthenticationManager
                .SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        public UserStatus Register(RegisterViewModel model)
        {
            try
            {
                var dubEmail = UserManager.FindByEmail(model.Email);
                if (dubEmail != null)
                {
                    return UserStatus.DublicationError;
                }
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };
                var result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    UserProfile userProfile = new UserProfile
                    {
                        Id = user.Id,
                        IsActive = true,
                        Phone = model.Phone//,
                        //Image = ""
                    };
                    _userReposittory.AddUserProfile(userProfile);
                    return UserStatus.Success;
                }
            }
            catch { }
            return UserStatus.Error;
            //throw new Exception("Bay");
            //ApplicationDbContext context = new ApplicationDbContext();

        }
    }
}
