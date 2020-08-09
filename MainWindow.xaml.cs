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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace organigramaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        double panelWidth;
        bool hide = true;
        double t = 35;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 5);
            timer.Tick += Timer_Tick;            
            panelWidth = sidePanel.Width;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hide)
            {
                t += 20;
                col1.Width = new GridLength(200);
                col2.Width = GridLength.Auto;
                sidePanel.Width = t;
                if (sidePanel.Width >= 200)
                {
                    timer.Stop();
                    hide = false;
                }
            }
            else
            {
                t -= 20;
                sidePanel.Width = t;
                col1.Width = new GridLength(35);
                col2.Width = GridLength.Auto;
                if (sidePanel.Width <= panelWidth)
                {
                    timer.Stop();
                    hide = true;
                }
            }
        }

        private void pnlHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void cierralo_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void abrelo_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void cierralo_MouseEnter(object sender, MouseEventArgs e)
        {
            cierralo.Background = Brushes.Red;
        }

        private void cierralo_MouseLeave(object sender, MouseEventArgs e)
        {
            cierralo.Background = Brushes.Transparent;            
        }
    }
}
