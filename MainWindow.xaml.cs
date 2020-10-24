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
using DROrdenes.UI.Registros;

namespace DROrdenes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void RegistrosOrdenes_Click(object sender, RoutedEventArgs e)
        {
            rOrdenes ventana = new rOrdenes();
            ventana.Show();
        }

        //  private void ConsultasOrdenes_Click(object sender, RoutedEventArgs e)
        // {
        //     rOrdenes ventana = new rOrdenes();
        //     ventana.Show();
        // }


    }
}
