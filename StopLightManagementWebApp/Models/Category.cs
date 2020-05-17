using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StopLightManagement.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        [StringLength(100)]
        public string Name { get; set; }

        public List<KPI> KPI { get; set; } = new List<KPI>();

    }
}
