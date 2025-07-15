using GameStore.Cms.Models.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Rest.Lookups
{
    public class GetLookupsModel
    {
        public List<LookupModel>? Items { get; set; }
    }
}
