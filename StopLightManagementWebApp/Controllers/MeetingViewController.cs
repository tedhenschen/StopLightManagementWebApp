using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using StopLightManagement.Models;
using StopLightManagementWebApp.Controllers.API_Controllers;
using StopLightManagementWebApp.Models.ViewModels;

namespace StopLightManagementWebApp.Controllers
{
    public class MeetingViewController : Controller
    {
        public async Task<ActionResult> Index(int orgNum = 0)
        {
            string url = "";
            List<Meeting> Model = null;
            if (orgNum > 0)
            {
                return View("OrganizationDetails");
            }
            else
            {
                url = "https://localhost:44375/api/Meetings";
            }

            var task = await APIHelper.ApiClient.GetAsync(url);
            var jsonString = await task.Content.ReadAsStringAsync();

            Model = JsonConvert.DeserializeObject<List<Meeting>>(jsonString);

            return View(Model);
        }

       

    }
}