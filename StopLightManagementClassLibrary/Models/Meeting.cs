﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StopLightManagement.Models
{
    public class Meeting
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int TierLevel { get; set; }
        [Required]
        public string Frequency { get; set; }

        public string SiteCode { get; set; }

        public int OrganizationID { get; set; }

        public DateTime DateCreated { get; set; }

        public Site Site { get; set; }

        public List<MeetingKPI> MeetingKPIs { get; set; } = new List<MeetingKPI>();

    }



}
