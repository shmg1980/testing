using OpenQA.Selenium;
using System;
using System.Linq;
using System.Collections.Generic;
using Aquality.Selenium.Core.Logging;

namespace UserInterface.Tests.Elements
{

    internal class CardComboBoxSelect : IWrapsElement
    {
        private readonly IWebElement element;

        public IWebElement WrappedElement => element;

        public IList<IWebElement> Options => element.FindElements(By.XPath("//div[@class='dropdown__list']//div"));

        public CardComboBoxSelect(IWebElement element)
        {
            if (element is null)
            {
                Logger.Instance.Error("Card combo box select element is null.");
                throw new ArgumentNullException("element", "Element cannot be null");
            }

            this.element = element;
        }

        public IWebElement SelectedOption
        {
            get
            {
                foreach (IWebElement option in Options)
                {
                    if (option.Selected)
                    {
                        return option;
                    }
                }

                Logger.Instance.Error("No option is selected.");
                throw new NoSuchElementException("No option is selected");
            }
        }

        public IList<IWebElement> AllSelectedOptions
        {
            get
            {
                var list = new List<IWebElement>();

                foreach (IWebElement option in Options)
                {
                    if (option.Selected)
                    {
                        list.Add(option);
                    }
                }

                return list;
            }
        }      

        public void SelectByText(string text)
        {
            if (text is null)
            {
                Logger.Instance.Error("Text to look for is null.");
                throw new ArgumentNullException("text", "Text must not be null");
            }

            element.Click();

            var o = new List<string>();

            foreach (var s in Options)
            {
                o.Add(s.Text);
            }

            SetSelected(Options.First(o => o.Text == text));
        }

        public void SelectByValue(string value)
        {
            if (value is null)
            {
                Logger.Instance.Error("Value to look for is null.");
                throw new ArgumentNullException("value", "Value must not be null");
            }

            SetSelected(Options.First(o => o.GetAttribute("value") == value));
        }

        public void SelectByIndex(int index)
        {
            if (index >= Options.Count() || index < 0)
            {
                Logger.Instance.Error("Index is out of range.");
                throw new ArgumentOutOfRangeException("index", "Index is out of range");
            }

            SetSelected(Options.ElementAt(index));
        }

        private static void SetSelected(IWebElement option)
        {
            option.Click();
        }
    }

}
