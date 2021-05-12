using StopLightManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopLightManagementWebApp.Models.ViewModels
{
    public class SiteMeetings
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int TierLevel { get; set; }

        public string Frequency { get; set; }

        public string SiteCode { get; set; }
       
    }

    public class NewMeeting
    {
        public int TierLevel { get; set; }

        public string Name { get; set; }

        public string Frequency { get; set; }

        public string SiteCode {get; set; }

        public int OrganizationID { get; set; }
    }

    public class AllMeetings
    {
        public string SiteCode { get; set; }

        public int OrganizationID { get; set; }

        public string Name { get; set; }

        public IEnumerable<Meeting> Meetings { get; set; }
    }
}
