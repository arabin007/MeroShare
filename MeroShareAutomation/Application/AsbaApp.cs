
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Chrome;
using System.Diagnostics.CodeAnalysis;
using SeleniumExtras.WaitHelpers;

public class AsbaApp
{
        
        private readonly IConfiguration _conf;

        public AsbaApp(IConfiguration conf)
        {
            _conf = conf;
        }
    public void ApplyForShare(IWebDriver webDriver, string User)
    {
        
        //Pass Asba URL
        By AsbaNav = By.CssSelector("a[href=\"#/asba\"]");
        CustomWaitForLoading(webDriver).Until(drv => drv.FindElement(AsbaNav));
        IWebElement webElementAsbaNav = webDriver.FindElement(AsbaNav);
        webElementAsbaNav.Click();
        //webDriver.Navigate().GoToUrl("https://meroshare.cdsc.com.np/#/asba");

        //Wait for User to click for the issue
        //&
        //Pass Bank
        By BankField = By.Id("selectBank");
        CustomWaitForLoading(webDriver).Until(drv => drv.FindElement(BankField));    
        IWebElement webElementBank = webDriver.FindElement(BankField);
        webElementBank.SendKeys(_conf.GetValue<string>($"MeroshareInfo:{User}:Bank"));

        By AccountNo = By.Id("accountNumber");
        CustomWaitForLoading(webDriver).Until(drv => drv.FindElement(AccountNo)); 
    
        // Locate the dropdown element
        IWebElement dropdownElement = webDriver.FindElement(AccountNo);

        // Wrap it in SelectElement
        SelectElement select = new SelectElement(dropdownElement);

        // Select the second option (index starts at 0)
        select.SelectByIndex(1); // 0 = first option, 1 = second option
        

        //Pass Applied Kitta  
        By KittaField = By.Id("appliedKitta");
        IWebElement webElementKitta = webDriver.FindElement(KittaField);
        webElementKitta.SendKeys(_conf.GetValue<string>($"MeroshareInfo:{User}:Kitta"));

        //Pass CRN
        By CRNField = By.Id("crnNumber");
        IWebElement webElementCRN = webDriver.FindElement(CRNField);
        webElementCRN.SendKeys(_conf.GetValue<string>($"MeroshareInfo:{User}:CRN"));  

        //Pass Tick to disclaimer
        By CheckButton = By.Id("disclaimer");
        IWebElement webElementLogin = webDriver.FindElement(CheckButton);
        webElementLogin.Click();

        //Click Proceed
        // By ProceedButton = By.CssSelector("button[type=\"submit\"]");

        // CustomWaitForLoading(webDriver)
        //     .Until(ExpectedConditions.ElementToBeClickable(ProceedButton));  
        // IWebElement webElementProceed = webDriver.FindElement(ProceedButton);
        // webElementProceed.Click();


        // Pass Transaction PIN
        By PINField = By.Id("transactionPIN");
        CustomWaitForLoading(webDriver).Until(ExpectedConditions.ElementToBeClickable(PINField));
        IWebElement webElementPIN = webDriver.FindElement(PINField);
        webElementPIN.SendKeys(_conf.GetValue<string>($"MeroshareInfo:{User}:PIN"));  
    }

    public WebDriverWait CustomWaitForLoading(IWebDriver webDriver){
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(20));
            wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            return wait;
    }
}