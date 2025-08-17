using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace MeroShareAutomation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeroshareController : ControllerBase
    {
       
        private readonly IConfiguration _conf;

        public MeroshareController(IConfiguration conf)
        {
            _conf = conf;
        }

        [HttpGet]
        public async Task<object> Get(string User = "Rabin")
        {
            IWebDriver webDriver = new ChromeDriver();

            LoginApp loginApp = new LoginApp(_conf);
            webDriver = loginApp.Login(webDriver, User);

            AsbaApp asbaApp = new AsbaApp(_conf);
            asbaApp.ApplyForShare(webDriver, User);
            
            string url = "Launching new instance...";
            return  url;
            
        }
    }
}
