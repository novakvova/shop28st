using BLL.ViewModels.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IAccountProvider
    {
        UserStatus Register(RegisterViewModel model);
        UserStatus Login(LoginViewModel model);
        void LogOff();
    }
}
