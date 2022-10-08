using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutoTestTasks.Pages
{
    public class ResultPage
    {
        protected readonly IWebDriver driver;

        public ResultPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public IWebElement searchField => driver.FindElement(By.Id("search_query_top"));
        public IWebElement headerText => driver.FindElement(By.ClassName("lighter"));

        public string GetInsertedWord() => searchField.GetAttribute("value").ToLower();
        public string GetDisplayedWord() => headerText.Text.TrimStart('\"').TrimEnd('\"').ToLower();
    }
}
