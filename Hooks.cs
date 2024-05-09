using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        _driver = new ChromeDriver(); // Initialize your WebDriver
        _scenarioContext["driver"] = _driver;
    }

    [AfterScenario]
    public void AfterScenario()
    {
        _driver.Quit(); // Close the WebDriver after the scenario
    }
}
