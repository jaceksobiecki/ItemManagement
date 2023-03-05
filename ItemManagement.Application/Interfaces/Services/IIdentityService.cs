using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.Application.Interfaces.Services
{
    public interface IIdentityService
    {
        Task<bool> UserIsAdmin();
    }
}
