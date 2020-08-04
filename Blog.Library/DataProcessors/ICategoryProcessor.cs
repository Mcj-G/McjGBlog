using Blog.Library.Models;
using System.Collections.Generic;

namespace Blog.Library.DataProcessors
{
    public interface ICategoryProcessor
    {
        List<CategoryModel> LoadCategories();
    }
}