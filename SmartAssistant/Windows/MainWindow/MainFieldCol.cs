using SmartAssistant.Infrastructure.Commands;
using SmartAssistant.Infrastructure.Styles.Base;
using SmartAssistant.Infrastructure.Styles.MainWindow;
using SmartAssistant.Resources;
using SmartAssistant.UserControls.Base;
using SmartAssistant.UserControls.MainWindow.Tabs.AboutTab;
using SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab;
using SmartAssistant.UserControls.MainWindow.Tabs.VAChatTab;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartAssistant.Windows.MainWindow
{
    public partial class MainWindow : Window
    {
        private List<Tab> tabs;

        private VAChatTab vAChatTab;
        private SettingsTab settingsTab;
        private AboutTab aboutTab;
        private Button wrapProgramButton;
        private Button collapseProgramButton;
        private Grid mainFieldGrid;
        private Border mainFieldColBorder;

        private Border ICMainFieldCol()
        {
            tabs = new List<Tab>();

            vAChatTab = new VAChatTab(id: 0, width: 535,
                height: 500, visibility: Visibility.Visible);
            tabs.Add(vAChatTab);
            settingsTab = new SettingsTab(id: 1, width: 535,
                height: 500, visibility: Visibility.Hidden);
            tabs.Add(settingsTab);
            aboutTab = new AboutTab(id: 2, width: 535,
                height: 500, visibility: Visibility.Hidden);
            tabs.Add(aboutTab);

            // TODO: Veser картинки на кнопки закрытия и сворачивания программы
            wrapProgramButton = new Button()
            {
                Style = new WarpAndCollapseProgramButtonStyle(new CornerRadius(0, 0, 0, 17), ResApp.GetResources<SolidColorBrush>("CommonDarkBrush")),
                Content = "-",
                Margin = new Thickness(0, 0, 39.5, 0),
                Command = new CloseApplicationCommand(),
                CommandParameter = false
            };

            collapseProgramButton = new Button()
            {
                Style = new WarpAndCollapseProgramButtonStyle(new CornerRadius(0, 17, 0, 0), ResApp.GetResources<SolidColorBrush>("Red")),
                Content = "X",
                Margin = new Thickness(0, 0, 0, 0),
                Command = new CloseApplicationCommand(),
                CommandParameter = true
            };

            mainFieldGrid = new Grid()
            {
                Margin = new Thickness(20, 0, 0, 0)
            };

            mainFieldGrid.Children.Add(vAChatTab);
            mainFieldGrid.Children.Add(settingsTab);
            mainFieldGrid.Children.Add(aboutTab);
            mainFieldGrid.Children.Add(collapseProgramButton);
            mainFieldGrid.Children.Add(wrapProgramButton);

            mainFieldColBorder = new Border()
            {
                Background = ResApp.GetResources<SolidColorBrush>("CommonLightBrush"),
                CornerRadius = new CornerRadius(0, 20, 20, 0),
                Margin = new Thickness(-20, 0, 0, 0),
                BorderThickness = new Thickness(4),
                BorderBrush = ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")
            };
            mainFieldColBorder.InputBindings.Add(dragMoveIB);
            mainFieldColBorder.Child = mainFieldGrid;
            return mainFieldColBorder;
        }
    }
}
