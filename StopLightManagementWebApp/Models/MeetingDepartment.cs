using StopLightManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StopLightManagementWebApp.Models
{
    public class MeetingDepartment
    {

        [Key]
        public int MeetingID { get; set; }
        [Key]
        public int DepartmentID { get; set; }


        //Relatiionships
        public Department Department { get; set; }
        public Meeting Meeting { get; set; }


    }
}
