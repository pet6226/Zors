using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zors.Services
{
    public interface IApprovalPageService
    {
        void ApproveRequest();
        void DenyRequest();
    }
}