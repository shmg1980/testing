using Aquality.Selenium.Elements;
using Aquality.Selenium.Elements.Actions;
using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using TgsARM.TestUtility.Elements;

namespace UserInterface.Tests.Elements
{

    internal class CardComboBox : Element, IComboBox
    {
        protected override string ElementType => LocalizationManager.GetLocalizedMessage("loc.combobox");

        private static readonly By optionLoc = By.XPath(@"//div[@class='dropdown__list']//div");

        public CardComboBox(By locator, string name, Aquality.Selenium.Core.Elements.ElementState state = 
            Aquality.Selenium.Core.Elements.ElementState.ExistsInAnyState) : 
            base(locator, name, state)
        {
        }

        private IList<IWebElement> Options => GetElement().FindElements(optionLoc);

        public string SelectedText
        {
            get
            {
                LogElementAction("loc.combobox.getting.selected.text");
                var text = DoWithRetry(() => new CardComboBoxSelect(GetElement()).SelectedOption.Text);
                LogElementAction("loc.combobox.selected.text", text);
                return text;
            }
        }

        public string SelectedValue
        {
            get
            {
                LogElementAction("loc.combobox.getting.selected.value");
                var value = DoWithRetry(() => new CardComboBoxSelect(GetElement()).SelectedOption.GetAttribute(AttributeName.Value));
                LogElementAction("loc.combobox.selected.value", value);
                return value;
            }
        }

        public IList<string> Texts
        {
            get
            {
                LogElementAction("loc.combobox.get.texts");
                var values = DoWithRetry(() => new CardComboBoxSelect(GetElement()).Options.Select(option => option.Text).ToList());
                LogElementAction("loc.combobox.texts", string.Join(", ", values.Select(value => $"'{value}'")));
                return values;
            }
        }

        public IList<string> Values
        {
            get
            {
                LogElementAction("loc.combobox.get.values");
                var values = DoWithRetry(() => new CardComboBoxSelect(GetElement()).Options.Select(option => option.GetAttribute(AttributeName.Value)).ToList());
                LogElementAction("loc.combobox.values", string.Join(", ", values.Select(value => $"'{value}'")));
                return values;
            }
        }

        public new ComboBoxJsActions JsActions => new ComboBoxJsActions(this, ElementType, LocalizedLogger, BrowserProfile);

        public void SelectByContainingText(string text)
        {
            LogElementAction("loc.combobox.select.by.text", text);

            DoWithRetry(() =>
            {
                var select = new CardComboBoxSelect(GetElement());

                foreach (var element in select.Options)
                {
                    var elementText = element.Text;

                    if (elementText.ToLower().Contains(text.ToLower()))
                    {
                        select.SelectByText(elementText);
                        return;
                    }
                }

                throw new InvalidElementStateException($"Failed to select option that contains text {text}");
            });
        }

        public void SelectByContainingValue(string value)
        {
            LogElementAction("loc.selecting.value", value);

            DoWithRetry(() =>
            {
                var select = new CardComboBoxSelect(GetElement());

                foreach (var element in select.Options)
                {
                    var elementValue = element.GetAttribute(AttributeName.Value);

                    if (elementValue.ToLower().Contains(value.ToLower()))
                    {
                        select.SelectByValue(elementValue);
                        return;
                    }
                }

                throw new InvalidElementStateException($"Failed to select option that contains value {value}");
            });
        }

        public void SelectByIndex(int index)
        {
            LogElementAction("loc.selecting.value", $"#{index}");
            DoWithRetry(() => new CardComboBoxSelect(GetElement()).SelectByIndex(index));
        }

        public void SelectByText(string text)
        {
            LogElementAction("loc.combobox.select.by.text", text);
            DoWithRetry(() => new CardComboBoxSelect(GetElement()).SelectByText(text));
        }

        public void SelectByValue(string value)
        {
            LogElementAction("loc.selecting.value", value);
            DoWithRetry(() => new CardComboBoxSelect(GetElement()).SelectByValue(value));
        }
    }

}
