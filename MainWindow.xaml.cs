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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace proyecto_GestorCine
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BaseDeDatos db;
        ApiRestCine apirest = new ApiRestCine();

        ObservableCollection<Peliculas> peliculas;
        public MainWindow()
        {
            InitializeComponent();
            db = new BaseDeDatos();
            peliculadDataGrid.AutoGenerateColumns = false;
            peliculas = apirest.obtenerTodasPeliculas();
            peliculadDataGrid.ItemsSource = peliculas;
            foreach (var item in peliculas)
            {
                Console.WriteLine(item.year);
            }
            // InsertarPeliculas();
        }

        public void InsertarPeliculas()
        {
            ObservableCollection<Peliculas> peliculas2;
            foreach (var item in peliculas)
            {
                db.InsertarPelicula(item);
            }
            peliculas2 = db.ObtenerPeliculas();
            foreach (var item in peliculas2)
            {
                Console.WriteLine(item);
            }
        }

        private void CommandBinding_Executed_edit(object sender, ExecutedRoutedEventArgs e)
        {
            ApiRestCine api = new ApiRestCine();
            editSessions editarSesion = new editSessions();
            editarSesion.Owner = this;
            if (editarSesion.ShowDialog() == true)
            {
                editarSesion.editComboBox.ItemsSource = api.obtenerTodasPeliculas();
            }

        }
      
        private void editarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TODO");
        }

        private void CommandBinding_Executed_pay(object sender, ExecutedRoutedEventArgs e)
        {
            Venta venta = new Venta();
            venta.Owner = this;
            if (venta.ShowDialog()==true)
            {

            }
        }
    }
}
