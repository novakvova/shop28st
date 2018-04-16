using BLL.Abstract;
using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserProvider _userProvider;
        public UserController(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }
        // GET: User
        public ActionResult Index()
        {
            var model = _userProvider.GetUsers(false);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var model = new UserCreateViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(UserCreateViewModel model)
        {
            //розмір фотки
            var fileSize = model.Image.ContentLength;
           // var model = new UserCreateViewModel();
            return View(model);
        }
    }
}