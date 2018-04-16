using BLL.Abstract;
using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Providers
{
    public class UserProvider : IUserProvider
    {
        public List<UserViewModel> GetUsers(bool isActive = true)
        {
            throw new NotImplementedException();
        }
    }
}
