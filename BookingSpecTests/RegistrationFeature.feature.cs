﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace BookingSpecTests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Registration")]
    public partial class RegistrationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "RegistrationFeature.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Registration", "", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Input valid credentials in order to Register")]
        public virtual void InputValidCredentialsInOrderToRegister()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Input valid credentials in order to Register", ((string[])(null)));
#line 3
this.ScenarioSetup(scenarioInfo);
#line 4
 testRunner.When("I open browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 5
 testRunner.And("I navigate to url \"https://booking.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 6
 testRunner.And("I click Register button on Ribbon menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table1.AddRow(new string[] {
                        "Email",
                        "testmirantistest@gmail.com"});
            table1.AddRow(new string[] {
                        "Password",
                        "1234qweR"});
#line 7
 testRunner.And("I set following parameters on Register Pop Up dialog", ((string)(null)), table1, "And ");
#line 11
 testRunner.And("I click Get Started button on PopUp", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.Then("I see that I am Signed In", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Attempt to Register using Invalid combinations of email and password")]
        [NUnit.Framework.TestCaseAttribute("2131312@.com", "1", "Password needs to be at least 8 characters long", null)]
        [NUnit.Framework.TestCaseAttribute("2131312@.com", "", "Please add a password", null)]
        [NUnit.Framework.TestCaseAttribute("2131312@.com", "wrongpass", "Please enter a valid email address.", null)]
        [NUnit.Framework.TestCaseAttribute("2131312.com", "12341234", "Please enter a valid email address.", null)]
        [NUnit.Framework.TestCaseAttribute("2131312@com", "12341234", "Please enter a valid email address.", null)]
        [NUnit.Framework.TestCaseAttribute("", "", "Please enter a valid email address.", null)]
        public virtual void AttemptToRegisterUsingInvalidCombinationsOfEmailAndPassword(string email, string password, string message, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Attempt to Register using Invalid combinations of email and password", exampleTags);
#line 14
this.ScenarioSetup(scenarioInfo);
#line 15
 testRunner.When("I open browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
 testRunner.And("I navigate to url \"https://booking.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("I click Register button on Ribbon menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table2.AddRow(new string[] {
                        "Email",
                        string.Format("{0}", email)});
            table2.AddRow(new string[] {
                        "Password",
                        string.Format("{0}", password)});
#line 18
 testRunner.And("I set following parameters on Register Pop Up dialog", ((string)(null)), table2, "And ");
#line 22
 testRunner.And("I click Get Started button on PopUp", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.Then("I wait while page popup is working", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
 testRunner.And(string.Format("I see message error with \"{0}\"", message), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Try to register as already registered user")]
        public virtual void TryToRegisterAsAlreadyRegisteredUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Try to register as already registered user", ((string[])(null)));
#line 35
this.ScenarioSetup(scenarioInfo);
#line 36
 testRunner.When("I open browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
 testRunner.And("I navigate to url \"https://booking.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.And("I click Register button on Ribbon menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table3.AddRow(new string[] {
                        "Email",
                        "testmirantistest@gmail.com"});
            table3.AddRow(new string[] {
                        "Password",
                        "1234qweR"});
#line 39
 testRunner.And("I set following parameters on Register Pop Up dialog", ((string)(null)), table3, "And ");
#line 43
 testRunner.And("I click Get Started button on PopUp", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.Then("I see that I am Signed In", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Attempt to register with already used email")]
        public virtual void AttemptToRegisterWithAlreadyUsedEmail()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Attempt to register with already used email", ((string[])(null)));
#line 46
this.ScenarioSetup(scenarioInfo);
#line 47
 testRunner.When("I open browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
 testRunner.And("I navigate to url \"https://booking.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.And("I click Register button on Ribbon menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table4.AddRow(new string[] {
                        "Email",
                        "testmirantistest@gmail.com"});
            table4.AddRow(new string[] {
                        "Password",
                        "12341234"});
#line 50
 testRunner.And("I set following parameters on Register Pop Up dialog", ((string)(null)), table4, "And ");
#line 54
 testRunner.And("I click Get Started button on PopUp", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.Then("I wait while page popup is working", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
 testRunner.Then("I see error message \"You entered an email address/password combination that doesn" +
                    "\'t match. I forgot\" on Register PopUp", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
 testRunner.When("I click on X button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 58
 testRunner.Then("I see that I am not Signed In", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 59
 testRunner.When("I click Sign In button on Ribbon menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table5.AddRow(new string[] {
                        "Email",
                        "testmirantistest@gmail.com"});
            table5.AddRow(new string[] {
                        "Password",
                        "12341234"});
#line 60
 testRunner.Then("I check that I am not Registered", ((string)(null)), table5, "Then ");
#line 64
 testRunner.Then("I wait while page popup is working", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 65
 testRunner.And("I see error message \"You entered an email address/password combination that doesn" +
                    "\'t match. I forgot\" on Sign In PopUp", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check maximum length for email field on Register PopUp")]
        public virtual void CheckMaximumLengthForEmailFieldOnRegisterPopUp()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check maximum length for email field on Register PopUp", ((string[])(null)));
#line 67
this.ScenarioSetup(scenarioInfo);
#line 68
 testRunner.When("I open browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 69
 testRunner.And("I navigate to url \"https://booking.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.And("I click Register button on Ribbon menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table6.AddRow(new string[] {
                        "Email",
                        "testmirantistesttestmirantistesttestmirantistesttestmirantistesttestmirantistest@" +
                            "gmail.ru"});
#line 71
 testRunner.And("I set following parameters on Register Pop Up dialog", ((string)(null)), table6, "And ");
#line 74
 testRunner.Then("I see that value of email field consists of 80 chars on Register Pop Up dialog", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check that previous values in Register PopUp fields are saved")]
        public virtual void CheckThatPreviousValuesInRegisterPopUpFieldsAreSaved()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that previous values in Register PopUp fields are saved", ((string[])(null)));
#line 76
this.ScenarioSetup(scenarioInfo);
#line 77
 testRunner.When("I open browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
 testRunner.And("I navigate to url \"https://booking.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.And("I click Register button on Ribbon menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table7.AddRow(new string[] {
                        "Email",
                        "testmirantistest@gmail.com"});
            table7.AddRow(new string[] {
                        "Password",
                        "1234qweR"});
#line 80
 testRunner.And("I set following parameters on Register Pop Up dialog", ((string)(null)), table7, "And ");
#line 84
 testRunner.And("I click on X button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
 testRunner.And("I click Register button on Ribbon menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.Then("I see that credential values: \"testmirantistest@mail.com\" \"1234qweR\" are \"saved\" " +
                    "in Register PopUp fields", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 87
 testRunner.When("I click Get Started button on PopUp", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 88
 testRunner.Then("I see that I am Signed In", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check that previous values in Register PopUp fields are not saved")]
        public virtual void CheckThatPreviousValuesInRegisterPopUpFieldsAreNotSaved()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that previous values in Register PopUp fields are not saved", ((string[])(null)));
#line 90
this.ScenarioSetup(scenarioInfo);
#line 91
 testRunner.When("I open browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 92
 testRunner.And("I navigate to url \"https://booking.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.And("I click Register button on Ribbon menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table8.AddRow(new string[] {
                        "Email",
                        "testmirantistest@gmail.com"});
            table8.AddRow(new string[] {
                        "Password",
                        "1234qweR"});
#line 94
 testRunner.And("I set following parameters on Register Pop Up dialog", ((string)(null)), table8, "And ");
#line 98
 testRunner.And("I click on X button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.And("I refresh page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.And("I click Register button on Ribbon menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.Then("I see that credential values: \"testmirantistest@mail.com\" \"1234qweR\" are \"not sav" +
                    "ed\" in Register PopUp fields", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 102
 testRunner.When("I click Get Started button on PopUp", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 103
 testRunner.Then("I see error message \"Please enter a valid email address.\" on Register PopUp", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
