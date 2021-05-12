using StopLightManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopLightManagementWebApp.Models.ViewModels
{
    public class KPIVM
    {
        public int ID { get; set; }

        public string PerformanceIndicator { get; set; }

        public DateTime? ActiveDate { get; set; }

        public List<Target> Target { get; set; } = new List<Target>();

        public DateTime DateCreated { get; set; }

        public Department Department { get; set; }

        public Category Category { get; set; }
    }
}
