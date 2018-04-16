using DAL.Abstract;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,
        CustomRole, int, CustomUserLogin,CustomUserRole, CustomUserClaim>, IAppDBContext
    {
        public ApplicationDbContext()
            : base("CovbaskaConnection")
        {

        }
        public ApplicationDbContext(string connString)
            : base(connString)
        {

        }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Вертає довільний Entity який є в контексті
        /// </summary>
        /// <typeparam name="TEntity">Тута вказуємо конкрений Entity</typeparam>
        /// <returns></returns>
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
