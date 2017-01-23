﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using Screenshot = KitchenSink.Tests_New.Utilities.Screenshot;

namespace KitchenSink.Tests_New.Utilities
{
    class EventListener : EventFiringWebDriver
    {
        public EventListener(IWebDriver driver) : base(driver)
        {
            ExceptionThrown += (sender, e) =>
            {
                if (e != null && sender != null)
                {
                    Screenshot.MakeScreenshot(e.Driver);
                }
            };
        }
    }
}