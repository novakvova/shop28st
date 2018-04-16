using DAL.Abstract;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IAppDBContext _context;
        public CategoryRepository(IAppDBContext context)
        {
            _context = context;
        }
        public Category Add(Category category)
        {
            _context.Set<Category>().Add(category);
            _context.SaveChanges();
            return category;
        }

        public Category Add(string name, int parentId)
        {
            Category category=new Category
            {
                Name=name,
                ParentId=parentId
            };
            return this.Add(category);
        }

        public IQueryable<Category> GetAll()
        {
            return _context.Set<Category>().AsQueryable();
        }

        public Category GetById(int id)
        {
            return 
                this.GetAll()
                .SingleOrDefault(c=>c.Id==id);
        }

        public void Remove(int id)
        {
            var category=this.GetById(id);
            if (category != null)
                _context.Set<Category>().Remove(category);
        }

        public int SaveChange()
        {
            return _context.SaveChanges();
        }
    }
}
