using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebAppKVDemo.Models;

namespace WebAppKVDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration Configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            try
            {
                // read secret1 from Azure Key Vault
                string kvUri =
                        "https://grobero-kv-demo.vault.azure.net/";
                SecretClient client =
                    new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

                string secret = client.GetSecretAsync("secretColour",
                    "b2829993bb5347a290bd0b869479d605").Result.Value.Value;
                ViewBag.secretColour = secret;

                // read secret2 from app settings
                // KV reference: @Microsoft.KeyVault(SecretUri=https://kv-204-demo01.vault.azure.net/secrets/secretName/1dea44bd3dcb451db5b5c4cab215d757)
                ViewBag.secretPerson = Configuration.GetSection("secretPerson").Value;
            }
            catch(Exception ex)
            {
                // Never return exception messages/details to the caller. The following code is only for demonration purpose.
                ViewBag.error = ex.Message;
            }            

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
