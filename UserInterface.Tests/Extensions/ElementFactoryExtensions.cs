using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;
using UserInterface.Tests.Elements;

namespace UserInterface.Tests.Extensions
{

    internal static class ElementFactoryExtensions
    {
        public static CardComboBox GetCardComboBox(this IElementFactory elementFactory, By elementLocator, string elementName) =>
            elementFactory.GetCustomElement(GetCardComboBoxSupplier(), elementLocator, elementName);

        private static ElementSupplier<CardComboBox> GetCardComboBoxSupplier() => 
            (locator, name, state) => new CardComboBox(locator, name, state);
    }

}
