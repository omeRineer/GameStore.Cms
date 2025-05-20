using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Auth
{
    public class AccessTokenModel
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
