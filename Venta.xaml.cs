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

namespace proyecto_GestorCine
{
    /// <summary>
    /// Lógica de interacción para Venta.xaml
    /// </summary>
    public partial class Venta : Window
    {
        BaseDeDatos db;
        public Venta()
        {
            InitializeComponent();
            db = new BaseDeDatos();
            peliculadDataGrid.AutoGenerateColumns = false;
            peliculadDataGrid.ItemsSource = db.ObtenerPeliculas(); 
        }

        private void peliculadDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
