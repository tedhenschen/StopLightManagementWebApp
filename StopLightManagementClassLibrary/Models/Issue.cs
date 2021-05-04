using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StopLightManagement.Models
{
    public class Issue
    {
        public int ID { get; set; }

        [Required]
        public string Statement { get; set; }

        public DateTime OriginalDueDate { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? RevisedDueDate { get; set; }

        [Required]
        //Need to set to default to a new status
        public IssueStatus Status { get; set; }

        [Required]
        public Employee RaisedBy { get; set; }

        [Required]
        public Employee Owner { get; set; }

        [Required]
        public Meeting RaisedAt { get; set; }

        public List<IssueComment> IssueComments { get; set; } = new List<IssueComment>();

    }
}