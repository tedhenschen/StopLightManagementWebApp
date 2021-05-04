using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StopLightManagement.Models
{
    public class Employee
    {

        public int Id { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(250)")]
        [StringLength(250)]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(250)")]
        [StringLength(250)]
        public string LastName { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        public Department department { get; set; }

        public List<Issue> IssuesOwned { get; set; } = new List<Issue>();
        public List<Issue> IssuesRaised { get; set; } = new List<Issue>();

    }
}
