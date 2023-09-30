using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SkyWalker_WPF.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Minimize(object sender, RoutedEventArgs e)
        {
            this.WindowState=WindowState.Minimized;
        }
        private void MaximizeOrRestore(object sender, RoutedEventArgs e)
        {
            this.WindowState = this.WindowState != WindowState.Maximized ? WindowState.Maximized : WindowState.Normal;
        }
        private void Close(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void DragMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton==MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
