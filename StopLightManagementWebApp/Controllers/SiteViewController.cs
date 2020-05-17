using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using StopLightManagementWebApp.Controllers.API_Controllers;
using StopLightManagementWebApp.Models.ViewModels;

namespace StopLightManagementWebApp.Controllers
{
    public class SiteViewController : Controller
    {

        //Default page
        public IActionResult Index()
        {
            return View();
        }


        // GET: SiteView/AddSite/1
        public IActionResult AddSite(int id)
        {
            SiteVM SiteVm = new SiteVM();
            SiteVm.OrganizationID = id;
            return View(SiteVm);
        }


        [HttpPost]
        public IActionResult ReturnOrganization(SiteVM sitevm)
        {
            return RedirectToAction($"OrganizationDetails", "OrganizationView", new { ID = sitevm.OrganizationID });

        }

        //POST: SiteView/AddSite
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSite(SiteVM SiteVm)
        {
            if (ModelState.IsValid)
            {
                string url = "https://localhost:44375/api/Sites/";
                var jsonString = JsonConvert.SerializeObject(SiteVm);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await APIHelper.ApiClient.PostAsync(url, httpContent);

                if (message.IsSuccessStatusCode)
                {
                    return RedirectToAction($"OrganizationDetails", "OrganizationView",new {ID = SiteVm.OrganizationID});
                }

            }
            return View();


        }



    }
}