using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zors.Entities;

namespace zors.Services
{
    public interface ICreationRequestService
    {
        Employee GetEmployeeCurrent(string mbr);
        Organization GetOrganization(string jobcode);
        double CalculateNewSalary(double newCoeff);
        void CreateRequest();
    }
}
