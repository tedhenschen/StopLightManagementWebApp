using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StopLightManagement.Models
{
    public class IssueStatus
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(25)")]
        [StringLength(25)]
        public string Name { get; set; }

        public List<Issue> Issues { get; set; } = new List<Issue>();
    }
}
