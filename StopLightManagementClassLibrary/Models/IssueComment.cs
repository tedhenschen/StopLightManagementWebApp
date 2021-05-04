using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace StopLightManagement.Models
{
    public class IssueComment
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Comments { get; set; }

        [Required]
        public Issue Issue { get; set; }
    }
}

