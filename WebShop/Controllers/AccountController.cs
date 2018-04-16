using BLL.Abstract;
using BLL.ViewModels.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountProvider _accountProvider;
        public AccountController(IAccountProvider accountProvider)
        {
            _accountProvider = accountProvider;
        }
        // GET: Account
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                //ModelState.AddModelError("", "Не тупи");
                var status=_accountProvider.Register(model);
                if (status == UserStatus.Error)
                {
                    ModelState.AddModelError("", "Щось пішло не так. " +
                        "Зверніться до служби підтримки(semen@mail.ru)-хру-хру");
                }
                else if(status == UserStatus.DublicationError)
                {
                    ModelState.AddModelError("", "Користувач з даним " +
                        "емейлом уже є.");
                }
                else
                {
                    return RedirectToAction("Index","Home");
                }
            }
            return View();
        }
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (!ModelState.IsValid)
                return View(model);
            var result = _accountProvider.Login(model);
            if(result==UserStatus.Success)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult LogOff()
        {
            _accountProvider.LogOff();
            return RedirectToAction("Index", "Home");
        }

    }
}