using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_GestorCine
{
    class conectionViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Peliculas> peliculas;
        ApiRestCine api = new ApiRestCine();



        public conectionViewModel()
        {
            peliculas = api.obtenerTodasPeliculas();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
