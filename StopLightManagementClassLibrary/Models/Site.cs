using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StopLightManagement.Models
{
    public class Site
    {


        [Key]
        [Column(TypeName = "NVARCHAR(10)")]
        [StringLength(10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SiteCode { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        [StringLength(100)]
        public string Name { get; set; }

        public List<Meeting> Meetings { get; set; } = new List<Meeting>();

        public List<Department> Departments { get; set; } = new List<Department>();

        public int OrganizationID { get; set; }

        public Organization Organization { get; set; }

        public DateTime DateCreated { get; set; }

        public static implicit operator Site(string v)
        {
            throw new NotImplementedException();
        }
    }
}

