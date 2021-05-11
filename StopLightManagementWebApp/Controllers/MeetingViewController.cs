﻿using System;
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

       

    }
}