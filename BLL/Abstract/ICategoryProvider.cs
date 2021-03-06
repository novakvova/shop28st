﻿using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface ICategoryProvider
    {
        IList<CategoryItemViewModel> GetCategories(int? parendId);
    }
}
