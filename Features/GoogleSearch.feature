Feature: Google Search
    In order to find information
    As an internet user
    I want to use Google to search for answers

@Firefox @Chrome
Scenario: Search for OpenAI on Google
    Given I have navigated to Google
    When I search for "OpenAI"
    Then the page title should contain "OpenAI"
