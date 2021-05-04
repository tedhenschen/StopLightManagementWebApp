using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;




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

