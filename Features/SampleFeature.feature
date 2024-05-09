Feature: Google Search1
    In order to find information
    As an internet user
    I want to use Google to search for answers

Scenario: Search for OpenAI on Google1
    Given I have navigated to Google
    When I search for "OpenAI"
    Then the page title should contain "OpenAI"
