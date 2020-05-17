using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StopLightManagement.Models
{
    public class Attendee
    {
        [Key]
        public int MeetingID { get; set; }

        [Key]
        public int EmployeeID { get; set; }


        //Relationships
        public Employee Employee { get; set; }
        public Meeting Meeting { get; set; }

    }
}
