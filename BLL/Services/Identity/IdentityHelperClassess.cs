﻿using DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Identity
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            //MailMessage mailMessage = new MailMessage
            //{
            //    Subject = message.Subject,
            //    Body = message.Body,
            //    IsBodyHtml = true
            //};
            //mailMessage.To.Add(new MailAddress(message.Destination));
            //SmtpClient smtpClient = new SmtpClient();
            //smtpClient.SendAsync(mailMessage, null);
            //return Task.FromResult(0);
            return Task.FromResult(0);
        }
    }
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
    public static class MyOptions
    {
        public static CookieAuthenticationOptions OptionCookies()
        {
            return new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator
                        .OnValidateIdentity<ApplicationUserManager, ApplicationUser, int>(
                            validateInterval: TimeSpan.FromMinutes(30),
                            regenerateIdentityCallback: (manager, user) =>
                                user.GenerateUserIdentityAsync(manager),
                            getUserIdCallback: (id) => (id.GetUserId<int>()))
                }
            };
        }
    }
}
