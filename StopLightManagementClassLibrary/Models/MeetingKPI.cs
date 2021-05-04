using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StopLightManagement.Models
{
    //This class handles a many to many relationship between KPI's and Meetings
    public class MeetingKPI
    {
        [Key]
        public int MeetingID { get; set; }
        [Key]
        public int KPIID { get; set; }


        //Relatiionships
        public KPI KPI { get; set; }
        public Meeting Meeting { get; set; }



    }
}
