using Microsoft.Win32;
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
    /// Lógica de interacción para editSessions.xaml
    /// </summary>
    public partial class editSessions : Window
    {

        ObservableCollection<Sesion> sesiones = new ObservableCollection<Sesion>();
        ObservableCollection<Peliculas> peliculas;
        ApiRestCine apirest = new ApiRestCine();
        public editSessions()
        {

            InitializeComponent();
            peliculas = apirest.obtenerTodasPeliculas();
            editComboBox.ItemsSource = peliculas;

        }

        private void subirButton_Click(object sender, RoutedEventArgs e)
        {
            Peliculas peliculas1;
            peliculas1 = (Peliculas)editComboBox.SelectedItem;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.Filter = "image files (*.png)|*.png|(*.jpg)|*.jpg|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = @"C:\Users\%USERNAME%\Documents";

            if (openFileDialog.ShowDialog() == true)
            {
                fotoTextBox.Text = openFileDialog.FileName;

            }
        }

        private void editComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Peliculas pelicula = (Peliculas)editComboBox.SelectedItem;
            TituloTextBox.Text = pelicula.titulo;
            fotoTextBox.Text = pelicula.cartel;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Sesion sesion = new Sesion();
            if (TituloTextBox.Text != null || horaTextBox.Text != null || salaTextBox.Text != null || fotoTextBox.Text != null)
            {
                sesion.pelicula = Convert.ToInt32( TituloTextBox.Text);
             
                sesion.hora = horaTextBox.Text;
                sesion.sala = Convert.ToInt32(salaTextBox.Text);

                sesiones.Add(sesion);
            }
        }
    }
}
