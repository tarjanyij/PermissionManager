using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionManager.Models
{
    public class Permission
    {
        public int PermissionID { get; set; }
        public int PersonID { get; set; }
        
        public int RightsID { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ApproverID { get; set; }
        public int ResponsibleID { get; set; }

        public Person Person { get; set; }
        
        public Rights Rights { get; set; }
        public Approver Approver { get; set; }
        public Responsible Responsible { get; set; }

    }
}
