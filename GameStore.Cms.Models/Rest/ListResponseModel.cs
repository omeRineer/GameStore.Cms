using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Rest
{
    public class ListResponseModel<TData>
    {
        public int Count { get; init; }
        public List<TData> Data { get; set; }
    }
}
