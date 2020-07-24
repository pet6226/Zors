using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zors.Entities;

namespace zors.Repositories
{
    public interface ICreationRequestRepository
    {
        List<Employee> SelectEmployeesByMbr(OracleConnection connection, string mbr);

        List<Organization> SelectOrganiyationByMbr(OracleConnection connection, string mbr);
    }
}
