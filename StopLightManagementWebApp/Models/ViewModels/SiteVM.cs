using StopLightManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopLightManagementWebApp.Models.ViewModels
{
    public class SiteVM
    {
        public string SiteCode { get; set; }

        public string Name { get; set; }

        public int OrganizationID { get; set; }
    }
    
    public class SiteMeetingVM
    {
        public string SiteCode { get; set; }

        public int OrganizationID { get; set; }

        public string Name { get; set; }

        public IEnumerable<Meeting> Meetings { get; set; }
    }
}
