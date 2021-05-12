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
        public async Task<ActionResult> Index(string sitecode)
        {
            string url;
            SiteMeetingVM siteMeetingVM;

            if (string.IsNullOrEmpty(sitecode))
            {
                return View("Index");
            }
            else
            {
                url = $"https://localhost:44375/api/Sites/GetSiteMeeting/{ sitecode}";
            }

            var task = await APIHelper.ApiClient.GetAsync(url);
            var jsonString = await task.Content.ReadAsStringAsync();

            siteMeetingVM = JsonConvert.DeserializeObject<SiteMeetingVM>(jsonString);

            return View(siteMeetingVM);
        }

        // GET: SiteView/AddMeeting
        public IActionResult AddMeeting(string sitecode, int id)
        {
            NewMeeting newMeeting = new NewMeeting
            {
                SiteCode = sitecode,
                OrganizationID = id
            };
            return View(newMeeting);
        }


        //POST: SiteView/AddMeeting
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMeeting(NewMeeting newMeeting)
        {
            if (ModelState.IsValid)
            {
                string url = "https://localhost:44375/api/Meetings/";
                var jsonString = JsonConvert.SerializeObject(newMeeting);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await APIHelper.ApiClient.PostAsync(url, httpContent);

                if (message.IsSuccessStatusCode)
                {
                    return RedirectToAction($"Index", "MeetingView", new { sitecode = newMeeting.SiteCode });
                }

            }
            return View();
        }

        public async Task<IActionResult> DeleteMeeting(string sitecode, int id)
        {
            string url;
            if (id > 0)
            {
                url = $"https://localhost:44375/api/Meetings/{ id}";
            }
            else
            {
                return RedirectToAction($"Index", "MeetingView", new { sitecode });
            }

            var task = await APIHelper.ApiClient.GetAsync(url);
            var jsonString = await task.Content.ReadAsStringAsync();

            SiteMeeting siteMeeting = JsonConvert.DeserializeObject<SiteMeeting>(jsonString);
            return View(siteMeeting);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteThisMeeting(SiteMeeting siteMeeting)
        {
            if (ModelState.IsValid)
            {
                string id = siteMeeting.ID.ToString();
                string url = $"https://localhost:44375/api/Meetings/{ id}";
                //var jsonString = JsonConvert.SerializeObject(organization);
                //var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await APIHelper.ApiClient.DeleteAsync(url);

                if (message.IsSuccessStatusCode)
                {
                    return RedirectToAction($"Index", "MeetingView", new { sitecode = siteMeeting.SiteCode });
                }

            }
            return RedirectToAction($"Index", "MeetingView", new { sitecode = siteMeeting.SiteCode });
        }


    }
}