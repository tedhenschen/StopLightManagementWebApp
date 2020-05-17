using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StopLightManagement.Models
{
    public class Target
    {

        public int Id { get; set; }

        public double? LowerRange { get; set; }

        public double? UpperRange { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(25)")]
        [StringLength(25)]
        public string UnitOfMeasure { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateChanged { get; set; }

        public DateTime? DateDisabled { get; set; }

        [Required]
        public KPI KPI { get; set; }

    }
}
