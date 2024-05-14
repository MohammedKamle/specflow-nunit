using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

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
        string browser = Environment.GetEnvironmentVariable("browser");

        switch (browser)
        {
            case "chrome":
                ChromeOptions capabilities = new ChromeOptions();
                capabilities.BrowserVersion = "latest";
                Dictionary<string, object> ltOptions = new Dictionary<string, object>();
                ltOptions.Add("username", "");
                ltOptions.Add("accessKey", "");
                ltOptions.Add("platformName", "Windows 10");
                ltOptions.Add("build", "lbs-debug");
                ltOptions.Add("w3c", true);
                ltOptions.Add("plugin", "c#-c#");
                capabilities.AddAdditionalOption("LT:Options", ltOptions);
                _driver = new RemoteWebDriver(new Uri("https://hub.lambdatest.com/wd/hub"), capabilities);
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                _scenarioContext["driver"] = _driver;
                break;
            case "firefox":
                FirefoxOptions firefoxOptions = new FirefoxOptions();
                firefoxOptions.BrowserVersion = "125";
                Dictionary<string, object> ltOptionsff = new Dictionary<string, object>();
                ltOptionsff.Add("username", "");
                ltOptionsff.Add("accessKey", "");
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
                _driver = new RemoteWebDriver(new Uri("https://<YOUR_USERNAME>>:<YOUR_ACCESS_KEY>@mobile-hub.lambdatest.com/wd/hub"), androidCaps);
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
