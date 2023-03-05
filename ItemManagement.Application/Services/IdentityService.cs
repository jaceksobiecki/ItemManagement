using ItemManagement.Application.Interfaces.Repositories;
using ItemManagement.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.Application.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAccessSettingsRepository _accessSettingsRepository;

        public IdentityService(IHttpContextAccessor httpContextAccessor, IAccessSettingsRepository accessSettingsRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _accessSettingsRepository = accessSettingsRepository;
        }

        public async Task<bool> UserIsAdmin()
        {
            var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var username = identity.FindFirst("preferred_username").Value.ToLower();
            var users = await _accessSettingsRepository.GetUsersByRole("ADMIN");

            return users.Contains(username);
        }
    }
}
