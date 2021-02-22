using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<Peliculas> peliculas;
        public Venta()
        {
            InitializeComponent();
            db = new BaseDeDatos();
            peliculadDataGrid.AutoGenerateColumns = false;
            peliculadDataGrid.ItemsSource = db.ObtenerPeliculas();
        }

        private void peliculadDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            efectivoRadioButton.IsEnabled = true;
            tarjetaRadioButton.IsEnabled = true;
            bizumRadioButton.IsEnabled = true;
        }

        private void cobrarButton_Click(object sender, RoutedEventArgs e)
        {
            Sesion sesion = new Sesion();
            peliculas = new ObservableCollection<Peliculas>();
            peliculadDataGrid.SelectedItem = peliculas;
            peliculas = db.getPelicula(peliculadDataGrid.SelectedIndex);


            Ventas ventas = new Ventas(peliculas.Count, (int)sesion.sala, sesion, 1, "7");
            db.InsertarVentas(ventas);

            MessageBox.Show(ventas.ToString());

        }
    }
}
