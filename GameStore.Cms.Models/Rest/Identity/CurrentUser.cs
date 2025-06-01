using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Rest.Identity
{
    public class CurrentUser
    {
        public Guid? Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string[]? Roles { get; set; }
        public string[]? Permissions { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
