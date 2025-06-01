using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.OData.Identity
{
    public class ODataUser : ODataModel<Guid>
    {
        public string Key { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthdayDate { get; set; }

        public IEnumerable<ODataUserRole>? UserRoles { get; set; }
        public IEnumerable<ODataUserPermission>? UserPermissions { get; set; }
    }

}
