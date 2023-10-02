using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGoogle.Fixtures
{
    public class TestFixtures : IDisposable
    {
        public IWebDriver Driver { get; set; }
        public TestFixtures()
        {
            Driver = new ChromeDriver();
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
