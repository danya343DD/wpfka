using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string[] colors = {
                "Navy", "Blue", "Aqua", "Teal", "Olive", "Green",
                "Lime", "Yellow", "Orange", "Red", "Maroon",
                "Fuchsia", "Purple", "Black", "Silver", "Gray", "White"
            };

            ColorButtonsList.ItemsSource = colors;
        }
    }
}