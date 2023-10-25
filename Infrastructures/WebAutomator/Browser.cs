using System;
using OpenQA.Selenium;

namespace Ban3.Infrastructures.WebAutomator;

public class OneBrowser :IDisposable
{
    private IWebDriver webDriver;

    public OneBrowser()
    {
        webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
    }



    public void Dispose()
    {
        if (webDriver != null)
        {
            webDriver.Close();
            webDriver.Dispose();
            webDriver.Quit();
        }
    }
}

