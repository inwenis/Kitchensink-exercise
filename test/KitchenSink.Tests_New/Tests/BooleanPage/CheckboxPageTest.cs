﻿using KitchenSink.Tests_New.Ui;
using KitchenSink.Tests_New.Ui.BooleanPage;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests_New.Tests.BooleanPage
{
    [TestFixture]
    class CheckboxPageTest : BaseTest
    {
        private CheckboxPage _checkboxPage;
        private MainPage _mainPage;

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _checkboxPage = _mainPage.GoToCheckboxPage();
        }

        [Test]
        public void CheckboxPage_CheckboxUncheckedAndCheckedAgain()
        {
            WaitUntil(x => _checkboxPage.Checkbox.Displayed);

            if (_checkboxPage.GetCheckboxState())
            {
                Assert.AreEqual("You can drive", _checkboxPage.InfoLabel.Text);
                _checkboxPage.ChangeCheckboxState();
                WaitUntil(ExpectedConditions.ElementSelectionStateToBe(_checkboxPage.Checkbox, false));
                Assert.AreEqual("You can't drive", _checkboxPage.InfoLabel.Text);
            }

            if (!_checkboxPage.GetCheckboxState())
            {
                Assert.AreEqual("You can't drive", _checkboxPage.InfoLabel.Text);
                _checkboxPage.ChangeCheckboxState();
                WaitUntil(ExpectedConditions.ElementSelectionStateToBe(_checkboxPage.Checkbox, true));
                Assert.AreEqual("You can drive", _checkboxPage.InfoLabel.Text);
            }
        }
    }
}
