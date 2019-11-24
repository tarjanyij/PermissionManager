using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionManager.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        public string PersonName { get; set; }
        public string PersonEmail { get; set; }
        public int OfficeID { get; set; }
        public Office Office { get; set; }

    }
}
