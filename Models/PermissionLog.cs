using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionManager.Models
{
    public class PermissionLog
    {
        public int PermissionLogID { get; set; }
        public int PermissionID { get; set; }
        public DateTime LogDate { get; set; }
        public string ModifiKey { get; set; }
        public string ModifyValue { get; set; }
        public Permission Permission { get; set; }
        
    }
}
