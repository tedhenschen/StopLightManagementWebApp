using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StopLightManagement.Models;
using StopLightManagementWebApp.Controllers.API_Controllers;
using StopLightManagementWebApp.Models.ViewModels;

namespace StopLightManagementWebApp.Controllers
{
    public class OrganizationViewController : Controller
    {
        // Get functions
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<ActionResult> Index(int? orgNum = 0)
        {
            string url = "";
            List<Organization> Model = null;
            if (orgNum > 0)
            {
                return View("OrganizationDetails");
            }
            else
            {
                url = "https://localhost:44375/api/Organizations";
            }

            var task = await APIHelper.ApiClient.GetAsync(url);
            var jsonString = await task.Content.ReadAsStringAsync();

            Model = JsonConvert.DeserializeObject<List<Organization>>(jsonString);

            return View(Model);
        }


        public IActionResult SiteView(string siteCode)
        {
            return RedirectToAction("SiteMeetings", "SiteView", new { SiteCode = siteCode });
        }



        /// Post Functions
        public IActionResult AddOrganization()
        {
            OganizationVM organization = new OganizationVM();
            return View(organization);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrganization(OganizationVM organization)
        {
            if (ModelState.IsValid)
            {
                string url = "https://localhost:44375/api/Organizations/";
                var jsonString = JsonConvert.SerializeObject(organization);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await APIHelper.ApiClient.PostAsync(url, httpContent);



                if (message.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            return RedirectToAction("Index");
        }

       
        public async Task<IActionResult> DeleteOrganization(int? ID)
        {
            string url = "";
            OrganizationIndexData organizationIndexData = null;

            if (ID > 0)
            {
                url = $"https://localhost:44375/api/Organizations/GetOrganizationDetails/{ ID}";
            }
            else
            {
                return View("Index");
            }

            var task = await APIHelper.ApiClient.GetAsync(url);
            var jsonString = await task.Content.ReadAsStringAsync();

            organizationIndexData = JsonConvert.DeserializeObject<OrganizationIndexData>(jsonString);


            return View(organizationIndexData);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteThisOrganization(OrganizationIndexData organization)
        {
            if (ModelState.IsValid)
            {
                string id = organization.ID.ToString();
                string url = $"https://localhost:44375/api/Organizations/DeleteOrganization/{ id}";
                //var jsonString = JsonConvert.SerializeObject(organization);
                //var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await APIHelper.ApiClient.DeleteAsync(url);

                if (message.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            return RedirectToAction("Index");
        }


    }
}