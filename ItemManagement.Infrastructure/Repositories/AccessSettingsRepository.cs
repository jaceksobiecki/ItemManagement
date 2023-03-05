using ItemManagement.Application.Interfaces.Repositories;
using ItemManagement.Infrastructure.Extensions.EfCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.Infrastructure.Repositories
{
    public class AccessSettingsRepository : IAccessSettingsRepository
    {
        private readonly DataContext _context;

        public AccessSettingsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<string>> GetUsersByRole(string roleId)
        {
            return await _context.AccessSettings
                .Where(x => x.Role.Id == roleId)
                .Select(x => x.UserId.Trim().ToLower())
                .ToListAsync();
        }
    }
}
