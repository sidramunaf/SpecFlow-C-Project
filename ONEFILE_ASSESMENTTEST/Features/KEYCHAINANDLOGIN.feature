
@keychain
Feature: User Create the Keychain Account logs in with valid credentials and Reset Password

  Background:
    Given   Navigate to the ONEFile Login Page using URL

  Scenario: Create the Keychain Account and logs in with valid credentials
    When    Click on the Create New Keychain
    And     Enter the First Name and Last Name
    And     Enter the Unique Email
    And     Enter the Password 
    And     Enter the Confirm Password
    And     Accept the Term and Conditions
    And     Click on the Register Button
    And     Click on the Back to Login Page Button
    And     Enter the Login Email and Password on the Login Page
    Then    Login Should be Done Successfully


    Scenario: Create the Keychain Account and Reset the password of the created account
    When    Click on the Create New Keychain
    And     Enter the First Name and Last Name
    And     Enter the Unique Email
    And     Enter the Password
    And     Enter the Confirm Password
    And     Accept the Term and Conditions
    And     Click on the Register Button
    And     Click on the Back to Login Page Button
    And     Enter the Login Email and Password on the Login Page
    And     Click on Setting Page and Reset the Password 
    Then    After Chaning the Password the User Should get LogOut

