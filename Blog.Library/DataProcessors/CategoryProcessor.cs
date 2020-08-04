using Blog.Library.DataAccess;
using Blog.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Library.DataProcessors
{
    public class CategoryProcessor : ICategoryProcessor
    {
        private readonly ISqlDataAccess _sql;

        public CategoryProcessor(ISqlDataAccess sql)
        {
            _sql = sql;
        }
        public List<CategoryModel> LoadCategories()
        {
            return _sql.LoadData<CategoryModel, dynamic>("dbo.spCategory_GetAll", new { }, "SQLData");
        }
    }
}
