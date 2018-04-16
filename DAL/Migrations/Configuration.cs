namespace DAL.Migrations
{
    using DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Entities.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Entities.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            InitCategory(context);

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
        public void InitCategory(DAL.Entities.ApplicationDbContext context)
        {
            context.Categories.AddOrUpdate(
                c => c.Id,
                new Category
                {
                    Id = 1,
                    Name = "Компьютеры и ноутбуки",
                    ParentId = null
                });

            context.Categories.AddOrUpdate(
                c => c.Id,
                new Category
                {
                    Id = 2,
                    Name = "Ноутбуки",
                    ParentId = 1
                });
            context.Categories.AddOrUpdate(
                c => c.Id,
                new Category
                {
                    Id = 3,
                    Name = "Планшети",
                    ParentId = 1
                });

            context.Categories.AddOrUpdate(
                c => c.Id,
                new Category
                {
                    Id = 4,
                    Name = "Смартфоны, ТВ и электроника",
                    ParentId = null
                });
        }
    }
}
