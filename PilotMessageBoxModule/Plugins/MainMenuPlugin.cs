using Ascon.Pilot.SDK;
using Ascon.Pilot.SDK.Menu;
using CommonLib.Controls;
using System.ComponentModel.Composition;
using System.Windows;

namespace PilotMessageBoxModule
{
    [Export(typeof(IMenu<MainViewContext>))]
    public class MainMenuPlugin : IMenu<MainViewContext>
    {
        private const string TEST_MENU_ITEM = "PilotMessageBoxItem";
        private const string TEST_MENU_ITEM_HEADER = "PilotMessageBox";

        public void Build(IMenuBuilder builder, MainViewContext context)
        {
            builder.AddItem(TEST_MENU_ITEM, 1).WithHeader(TEST_MENU_ITEM_HEADER);
        }

        public void OnMenuItemClick(string name, MainViewContext context)
        {
            if (name == TEST_MENU_ITEM)
            {
                PilotMessageBox.Show("Нет сообщений искомого типа");

                PilotMessageBox.Show("Нет сообщений искомого типа",
                                     "Внимание!");

                PilotMessageBox.Show("Нет сообщений искомого типа. Продолжить?",
                                     "Внимание!",
                                     MessageBoxButton.YesNo);

                PilotMessageBox.Show("Нет сообщений искомого типа. Продолжить?",
                                     "Внимание!",
                                     MessageBoxButton.YesNo,
                                     MessageBoxImage.Warning);
            }
        }
    }
}