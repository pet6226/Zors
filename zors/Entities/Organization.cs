using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zors.Entities
{
    public class Organization: Entity
    {
        public string OrganisationDepartmentNameSer { get; set; }
        public string OrganisationDepartmentNameEng { get; set; }
        public string JobNameSer { get; set; }
        public string JobNameEng { get; set; }
        public string JobID { get; set; }
    }
}