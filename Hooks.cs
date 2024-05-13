using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Configuration;
using System.Collections.Specialized;
using System.Configuration;
using System.Xml.Linq;



[Binding]
public class Hooks
{
    private readonly ScenarioContext _scenarioContext;
    private IWebDriver _driver;
    

    public Hooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        //string browser = Environment.GetEnvironmentVariable("browser");
        // string browser = _scenarioContext.ScenarioInfo.Tags.Contains("Chrome") ? "Chrome" : "Firefox";
        // Console.WriteLine("BROWSER IS :: " + _scenarioContext.ScenarioInfo.Tags.Contains("Chrome"));
        // string browser =  ConfigurationManager.AppSettings["Browser"];

         XDocument doc = XDocument.Load("app.config");
        XElement browserElement = doc.Descendants("add")
                                     .FirstOrDefault(e => e.Attribute("key")?.Value == "Browser");
         string browser = browserElement?.Attribute("value")?.Value;

         Console.WriteLine("BROWSER IS :: " + browser);

        switch (browser)
        {
            case "Chrome":
                ChromeOptions capabilities = new ChromeOptions();
                capabilities.BrowserVersion = "latest";
                Dictionary<string, object> ltOptions = new Dictionary<string, object>();
                ltOptions.Add("username", "mohammadk");
                ltOptions.Add("accessKey", "gkrzT0iFKjDjehXpMTznxM1lHIZXSYjV3H8Ntk0s2rCUJJO3WU");
                ltOptions.Add("platformName", "Windows 10");
                ltOptions.Add("build", "lbs-debug");
                ltOptions.Add("w3c", true);
                ltOptions.Add("plugin", "c#-c#");
                capabilities.AddAdditionalOption("LT:Options", ltOptions);
                _driver = new RemoteWebDriver(new Uri("https://hub.lambdatest.com/wd/hub"), capabilities);
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                _scenarioContext["driver"] = _driver;
                break;
            case "Firefox":
                FirefoxOptions firefoxOptions = new FirefoxOptions();
                firefoxOptions.BrowserVersion = "125";
                Dictionary<string, object> ltOptionsff = new Dictionary<string, object>();
                ltOptionsff.Add("username", "mohammadk");
                ltOptionsff.Add("accessKey", "gkrzT0iFKjDjehXpMTznxM1lHIZXSYjV3H8Ntk0s2rCUJJO3WU");
                ltOptionsff.Add("platformName", "Windows 10");
                ltOptionsff.Add("build", "lbs-debug");
                ltOptionsff.Add("w3c", true);
                firefoxOptions.AddAdditionalOption("LT:Options", ltOptionsff);
                firefoxOptions.AddAdditionalOption("LT:Options", ltOptionsff);
                _driver = new RemoteWebDriver(new Uri("https://hub.lambdatest.com/wd/hub"), firefoxOptions);
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                _scenarioContext["driver"] = _driver;
                break;
            case "android":
                ChromeOptions androidCaps = new ChromeOptions();
                Dictionary<string, object> ltOptionsAndroid = new Dictionary<string, object>();
                ltOptionsAndroid.Add("platformName", "Android");
                ltOptionsAndroid.Add("project", "Demo LT");
                ltOptionsAndroid.Add("build", "lbs-debug");
                ltOptionsAndroid.Add("sessionName", "C# Single Test");
                ltOptionsAndroid.Add("isRealMobile", true);
                ltOptionsAndroid.Add("deviceName", "Pixel.*");
                androidCaps.AddAdditionalOption("LT:Options", ltOptionsAndroid);
                _driver = new RemoteWebDriver(new Uri("https://mohammadk:gkrzT0iFKjDjehXpMTznxM1lHIZXSYjV3H8Ntk0s2rCUJJO3WU@mobile-hub.lambdatest.com/wd/hub"), androidCaps);
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                _scenarioContext["driver"] = _driver;     
                break;
            default:
                Console.WriteLine("Invalid browser");
                break;

        }

    }


    [AfterScenario]
    public void AfterScenario()
    {
        _driver.Quit(); // Close the WebDriver after the scenario
    }
}

     [TestFixture]
    [Parallelizable(ParallelScope.Children)] // Run tests in parallel
    public class TestClass
    {
        [Test]
        [TestCase("Chrome")]
        [TestCase("Firefox")]
        public void ExecuteFeature(string browser)
        {   
            string featureFilePath = @"path\to\your\feature.feature";

            // Initialize the SpecFlow runtime
            var testRunner = new TestRunner();
            
            // Execute the feature file
            var testResult = testRunner.RunScenario( "/Users/mohammadk/SpecFlowNUnitProject/Features/GoogleSearch.feature");

            System.Console.WriteLine($"Executing feature on {browser}");
        }
    }
