using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Rest
{
    public class DataResponseModel<TData>:ResponseModel
    {
        public TData? Data { get; set; }
    }
}
