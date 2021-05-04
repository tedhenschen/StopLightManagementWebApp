using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StopLightManagement.Models
{



    public class KPI
    {
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        [StringLength(100)]
        public string PerformanceIndicator { get; set; }

        public DateTime? ActiveDate { get; set; }

        public List<Target> Target { get; set; } = new List<Target>();

        public DateTime DateCreated { get; set; }

        [Required]
        public Department Department { get; set; }

        [Required]
        public Category Category { get; set; }

    }
}
