using GameStore.Cms.Models.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Rest.Category
{
    public class GetCategoriesModel
    {
        public List<CategoryModel>? Categories { get; set; }
    }
}
