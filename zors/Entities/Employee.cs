using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zors.Entities
{
    public class Employee: Entity
    {
        public string EmployeeMbr { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeSchool { get; set; }
        public string EmployeeProfessionalQualification { get; set; }
        public string EmployeeEducation { get; set; }
        public string EmployeeEducationSection { get; set; }
        public string EmployeeEducationCityPlace { get; set; }
        public string EmployeeEducationDate { get; set; }
        public string EmployeeEducationAverageMark { get; set; }
        public string EmployeeEducationAverageGraduateMark { get; set; }
        public string EmployeeEducationReference { get; set; }
        public string EmployeeCurrentDepartmentID { get; set; }
        public Organization Organization { get; set; }
        //public string EmployeeCurrentDepartmentSerName { get; set; }
        //public string EmployeeCurrentDepartmentEngName { get; set; }
        //public string EmployeeCurrentJobNameSer { get; set; }
        //public string EmployeeCurrentJobNameID { get; set; }
        //public string EmployeeCurrentJobNameEng { get; set; }
        public string EmployeeCurrentCoefficient { get; set; }
        public string Message { get; set; }

    }
}