using StopLightManagement.Context;
using StopLightManagementWebApp.Controllers.API_Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Security.Permissions;
using System.Threading.Tasks;




namespace StopLightManagement.Models
{


     public class Organization
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public List<Site> Sites { get; set; } = new List<Site>();

    }

}

