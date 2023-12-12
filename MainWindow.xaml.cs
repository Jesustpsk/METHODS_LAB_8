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

namespace METHODS_LAB_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static double[] x = {61.10, 60.80, 60.18, 59.20, 58.19, 55.29, 49.10};
        private static double[] y = {49.10, 48.60, 50.10, 52.20, 53.60, 58.10, 69.10};
        
        private static double[] xtest = {5.10, 4.80, 4.18, 3.20, 3.19, 2.29, 2.10};
        private static double[] ytest = {9.10, 8.60, 8.10, 7.20, 6.60, 6.10, 5.10};
        public MainWindow()
        {
            //для теста
            //x = xtest;
            //y = ytest;
            //-------
            InitializeComponent();
            
            TBInput.Text = "x: [ ";
            foreach (var _ in x)
            {
                TBInput.Text += _ + "; ";
            }

            TBInput.Text += "].\ny: [ ";
            foreach (var _ in y)
            {
                TBInput.Text += _ + "; ";
            }

            TBInput.Text += "].";
        }
        
        private void BStart_OnClick(object sender, RoutedEventArgs e)
        {
            LeastSquareMethod.Render(x,y,WpfPlot);
        }
    }
}