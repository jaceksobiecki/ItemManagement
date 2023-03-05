using ItemManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.Application.Interfaces.Repositories
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAll();
        Task<bool> Add(Item item);
        Task<bool> Update(Item item);
    }
}
