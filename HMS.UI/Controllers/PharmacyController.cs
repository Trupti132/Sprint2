using HMS.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HMS.UI.Controllers
{
    public class PharmacyController : Controller
    {
        private IConfiguration _configuration;
        public PharmacyController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> PharmacyIndex()
        {
            IEnumerable<Pharmacy> pharmacyresult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Pharmacy/GetMedicines";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        pharmacyresult = JsonConvert.DeserializeObject<IEnumerable<Pharmacy>>(result);
                    }
                }
            }
            return View(pharmacyresult);
        }
        public IActionResult AddMedicine()
        {
            return View();
        }
        [HttpPost("AddMedicine")]
        public async Task<IActionResult> AddMedicine(Pharmacy pharmacy)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(pharmacy), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Pharmacy/AddMedicine";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "  Medicine details saved successfully!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();
        }
    }
    
}
