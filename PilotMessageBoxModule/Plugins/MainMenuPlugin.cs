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
        private const string DIALOG_MENU = "DialogMenu";
        private const string DIALOG_MENU_HEADER = "PilotMessageBox";

        public void Build(IMenuBuilder builder, MainViewContext context)
        {
            var item = builder.AddItem(DIALOG_MENU, 1).WithHeader(DIALOG_MENU_HEADER);
        }

        public void OnMenuItemClick(string name, MainViewContext context)
        {
            if (name == DIALOG_MENU)
            {
                //PilotMessageBox.Show("Нет маршрутов для данного типа целевого объекта",
                //                    "Внимание",
                //                    MessageBoxButton.OK,
                //                    MessageBoxImage.Warning);

                PilotMessageBox.Show("Нет маршрутов для данного типа целевого объекта");
            }
        }
    }
}