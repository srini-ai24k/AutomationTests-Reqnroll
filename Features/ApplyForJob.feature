Feature: Apply for a job at LabCorp

  Scenario: Search and view a job at LabCorp
    Given I launch the LabCorp application
    And I navigate to LabCorp careers page
    And I search for "QA Automation Engineer"
    When I select the first job listing
    Then I should see the job details
    And I click on Apply Now
    And I should see the start application form
    When I click on autofill with resume
    And I should see create account form
    And I click on back to job posting
    Then I should see the job details again
    And I Validate the job details
    And I return to job search