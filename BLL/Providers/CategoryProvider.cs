using BLL.Abstract;
using BLL.ViewModels;
using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Providers
{
    public class CategoryProvider : ICategoryProvider
    {
        private readonly ICategoryRepository _categoryRepository;
       
        public CategoryProvider(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            
        }

        public IList<CategoryItemViewModel> GetCategories(int? parendId)
        {
            throw new NotImplementedException();
        }
    }
}
