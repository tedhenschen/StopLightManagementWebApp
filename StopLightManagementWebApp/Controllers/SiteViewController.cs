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
        public  async Task<IActionResult> Index(int? id)
        {
            string url;
            if (id > 0)
            {
                url = $"https://localhost:44375/api/Organizations/GetOrganizationDetails/{ id}";
            }
            else
            {
                return RedirectToAction("Index", "OrganizationView", new { orgnum = id });
            }

            var task = await APIHelper.ApiClient.GetAsync(url);
            var jsonString = await task.Content.ReadAsStringAsync();

            OrganizationIndexData organizationIndexData = JsonConvert.DeserializeObject<OrganizationIndexData>(jsonString);
            return View(organizationIndexData);
        }


        // GET: SiteView/AddSite/1
        public IActionResult AddSite(int id)
        {
            SiteVM SiteVm = new SiteVM
            {
                OrganizationID = id
            };
            return View(SiteVm);
        }


        [HttpPost]
        public IActionResult ReturnOrganization(SiteVM sitevm)
        {
            return RedirectToAction($"Index", "SiteView", new { ID = sitevm.OrganizationID });

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
                    return RedirectToAction($"Index", "SiteView", new {ID = SiteVm.OrganizationID});
                }

            }
            return View();
        }

        public async Task<IActionResult> DeleteSite(string siteCode, int organizationID)
        {
            string url;
            if ((organizationID > 0) && (siteCode != null))
            {
                url = $"https://localhost:44375/api/Sites/{ siteCode}/{ organizationID}";
            }
            else
            {
                return RedirectToAction($"Index", "SiteView", new { id = organizationID });
            }

            var task = await APIHelper.ApiClient.GetAsync(url);
            var jsonString = await task.Content.ReadAsStringAsync();

            SiteVM siteMeeting = JsonConvert.DeserializeObject<SiteVM>(jsonString);
            return View(siteMeeting);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteThisSite(SiteVM SiteVM)
        {
            if (ModelState.IsValid)
            {
                string organizationID = SiteVM.OrganizationID.ToString();
                string siteCode = SiteVM.SiteCode;
                string url = $"https://localhost:44375/api/Sites/{ siteCode}/{ organizationID}";
                //var jsonString = JsonConvert.SerializeObject(organization);
                //var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await APIHelper.ApiClient.DeleteAsync(url);

                if (message.IsSuccessStatusCode)
                {
                    return RedirectToAction($"Index", "SiteView", new { id = SiteVM.OrganizationID });
                }

            }
            return RedirectToAction($"Index", "SiteView", new { id = SiteVM.OrganizationID });
        }

    }
}