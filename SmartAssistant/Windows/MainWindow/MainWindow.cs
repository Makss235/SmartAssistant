using SmartAssistant.Data.LocalizationData;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace SmartAssistant.Windows.MainWindow
{
    public partial class MainWindow : Window
    {
        private InputBinding dragMoveIB;
        private DropShadowEffect dropShadowEffect;

        private ColumnDefinition headingMenuColumnDefinition;
        private ColumnDefinition leftMenuColumnDefinition;
        private ColumnDefinition mainFieldColumnDefinition;
        private Grid mainGrid;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Width = 850;
            Height = 550;
            Title = Localize.JsonObject.MainWindowLoc.TitleLoc;

            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            WindowStyle = WindowStyle.None;
            Background = new SolidColorBrush(Colors.Transparent);
            AllowsTransparency = true;

            dropShadowEffect = new DropShadowEffect()
            {
                ShadowDepth = 5,
                BlurRadius = 15,
                Opacity = 0.5
            };
            Effect = dropShadowEffect;

            headingMenuColumnDefinition = new ColumnDefinition()
            { Width = new GridLength(45, GridUnitType.Pixel) };

            leftMenuColumnDefinition = new ColumnDefinition()
            { Width = new GridLength(220, GridUnitType.Pixel) };

            mainFieldColumnDefinition = new ColumnDefinition()
            { Width = new GridLength(535, GridUnitType.Pixel) };

            Grid.SetColumn(ICHeadingMenuCol(), 0);
            Grid.SetColumn(ICLeftMenuCol(), 1);
            Grid.SetColumn(ICMainFieldCol(), 2);

            mainGrid = new Grid()
            {
                Width = 800,
                Height = 500
            };
            mainGrid.ColumnDefinitions.Add(headingMenuColumnDefinition);
            mainGrid.ColumnDefinitions.Add(leftMenuColumnDefinition);
            mainGrid.ColumnDefinitions.Add(mainFieldColumnDefinition);

            mainGrid.Children.Add(mainFieldColBorder);
            mainGrid.Children.Add(leftMenuColBorder);
            mainGrid.Children.Add(headingMenuColBorder);

            Content = mainGrid;
        }
    }
}
