using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.Domain.Models
{
    public class AccessSetting
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public Role Role { get; set; }
    }
}
