using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItemManagement.Domain.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Index(IsUnique = true)]
        [StringLength(200)]
        public string Name { get; set; }
        [Index(IsUnique = true)]
        [StringLength(12)]
        public string Code { get; set; }
        public string Color { get; set; }
        public string Remarks { get; set; }
    }
}
