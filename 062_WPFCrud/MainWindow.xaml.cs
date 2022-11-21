using System.Windows;
using System.Windows.Controls;

namespace _062_WPFCrud
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame StaticMainFrame;
        public MainWindow()
        {
            InitializeComponent();
            StaticMainFrame = MainFrame;
        }
    }
}
