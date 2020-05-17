using StopLightManagement.Models;
using StopLightManagementWebApp.Controllers.API_Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StopLightManagementWebApp.Controllers
{
    public class MeetingProcessor
    {
        public async Task<Organization> LoadOrganization(int orgNum = 0)
        {
            string url = "";

            if (orgNum > 0)
            {
                url = $"https://localhost:44375/api/Organizations/GetOrganizationDetails/{ orgNum}";
            }
            else
            {
                url = "https://localhost:44375/api/Organizations";
            }

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))            {
                if (response.IsSuccessStatusCode)
                {
                    Organization Organization = await response.Content.ReadAsAsync<Organization>();

                    return Organization;
                }
                else 
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }

    }
}
