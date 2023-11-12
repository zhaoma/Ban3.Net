// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;
using OpenQA.Selenium;

namespace Ban3.Infrastructures.WebAutomator;

/// <summary>
/// 
/// </summary>
public class OneBrowser :IDisposable
{
    private IWebDriver webDriver;

    public OneBrowser()
    {
        webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
    }

    /// <summary>
    /// WHEN/THEN
    /// 执行/赋值/修改属性 - 验证/确认
    /// </summary>
    /// <returns></returns>
    public bool Execute(string xPath, Func<string, bool> execute)
        => execute(xPath);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing && webDriver != null)
            {
                webDriver.Close();
                webDriver.Dispose();
                webDriver.Quit();
            }

            _disposed = true;
        }
    }

    ~OneBrowser()
    {
        Dispose(false);
    }

    private bool _disposed;
}

