using StopLightManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopLightManagementWebApp.Models.ViewModels
{
    public class OganizationVM
    {
        public string Name { get; set; }
    }


    public class OrganizationIndexData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<Site> Sites { get; set; }
    }

}
