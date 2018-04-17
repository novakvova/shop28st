using BLL.Abstract;
using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            if (ModelState.IsValid)
            {
                string pathServer = ConfigurationManager.AppSettings["UserImagePath"];
                string path = Server.MapPath(pathServer);
                int id = _userProvider.Create(model, path);
                if(id!=0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}