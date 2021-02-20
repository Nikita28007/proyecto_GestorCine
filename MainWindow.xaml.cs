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
         
         ApiRestCine apirest = new ApiRestCine();

        ObservableCollection<Peliculas> peliculas;
        public MainWindow()
        {
            InitializeComponent();
            peliculadDataGrid.AutoGenerateColumns = false;
            peliculas = apirest.obtenerTodasPeliculas();
            peliculadDataGrid.ItemsSource = peliculas;
           

        }

        private void CommandBinding_Executed_edit(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void editarButton_Click(object sender, RoutedEventArgs e)
        {
            ApiRestCine api = new ApiRestCine();
            editSessions editarSesion = new editSessions();
            editarSesion.Owner = this;
            if (editarSesion.ShowDialog() == true)
            {
                editarSesion.editComboBox.ItemsSource = api.obtenerTodasPeliculas();
            }
            else { MessageBox.Show("no funciona"); }
        }

        private void help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TODO");
        }

        

    }
}
