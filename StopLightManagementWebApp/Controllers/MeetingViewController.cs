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
        public IActionResult Index()
        {
            return View();
        }
    }
}