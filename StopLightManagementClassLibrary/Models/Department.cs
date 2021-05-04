using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StopLightManagement.Models
{
    public class Department
    {
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        [StringLength(100)]
        public string Name { get; set; }

        public List<KPI> KPIS { get; set; } = new List<KPI>();

        public List<Employee> Employee { get; set; } = new List<Employee>();

        public DateTime DateCreated { get; set; }

        public Site Site { get; set; }
    }
}