using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionManager.Models
{
    public class Rights
    {
        public int RightsID { get; set; }
        public string RightsName { get; set; }
        public string RightsValue { get; set; }
        public int OfficeRightsID { get; set; }
        public OfficeRights OfficeRights { get; set; }

    }
}
