
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Chrome;

public class LoginApp
{
        
        private readonly IConfiguration _conf;

        public LoginApp(IConfiguration conf)
        {
            _conf = conf;
        }
    public IWebDriver Login(IWebDriver webDriver, string User)
    {
            // Get to Meroshare Homepage
            webDriver.Navigate().GoToUrl(_conf.GetValue<string>($"MeroshareInfo:{User}:Url"));
            
            //Pass username
            By UsernameField = By.Id("username");
            CustomWaitForLoading(webDriver).Until(drv => drv.FindElement(UsernameField));
            IWebElement webElementUsername = webDriver.FindElement(UsernameField);
            webElementUsername.SendKeys(_conf.GetValue<string>($"MeroshareInfo:{User}:Username"));

            //Pass password
            By PasswordField = By.Id("password");
            CustomWaitForLoading(webDriver).Until(drv => drv.FindElement(PasswordField));
            IWebElement webElementPassword = webDriver.FindElement(PasswordField);
            webElementPassword.SendKeys(_conf.GetValue<string>($"MeroshareInfo:{User}:Password"));

            //Click DP Id
            By DBIDFieldClick = By.ClassName("select2-selection__rendered");
            CustomWaitForLoading(webDriver).Until(drv => drv.FindElement(DBIDFieldClick));
            IWebElement webElementDPID = webDriver.FindElement(DBIDFieldClick);
            webElementDPID.Click();

            //Pass DP Id
            By DBIDField = By.ClassName("select2-search__field");
            CustomWaitForLoading(webDriver).Until(drv => drv.FindElement(DBIDField));
            IWebElement webElementDPIDclicked = webDriver.FindElement(DBIDField);
            webElementDPIDclicked.SendKeys(_conf.GetValue<string>($"MeroshareInfo:{User}:DPID"));
            webElementDPIDclicked.SendKeys(Keys.Return);

           //Click Login
            By LoginButton = By.TagName("button");
            CustomWaitForLoading(webDriver).Until(drv => drv.FindElement(LoginButton));
            IWebElement webElementLogin = webDriver.FindElement(LoginButton);
            webElementLogin.Click();

            

            return webDriver;
    }

    public WebDriverWait CustomWaitForLoading(IWebDriver webDriver){
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(20));
            wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            return wait;
    }
}