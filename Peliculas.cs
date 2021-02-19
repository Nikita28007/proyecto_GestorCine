

using System.ComponentModel;

namespace proyecto_GestorCine
{
    class Peliculas : INotifyPropertyChanged
    {
        public int? id
        {
            get; set;
        }
        public string titulo
        {
            get; set;
        }
        public string cartel
        {
            get; set;
        }
        public int? year
        {
            get; set;
        }
        public string genero
        {
            get; set;
        }
        public string calificacion
        {
            get; set;
        }

        public Peliculas()
        {
            id = null;
            year = null;
            titulo = "";
            cartel = "";
            genero = "";
            calificacion = "";
        }

        public Peliculas(int? id, string titulo, string cartel, int? year, string genero, string calificacion)
        {
            this.id = id;
            this.titulo = titulo;
            this.cartel = cartel;
            this.year = year;
            this.genero = genero;
            this.calificacion = calificacion;
        }

        public Peliculas(Peliculas copy)
        {
            id = copy.id;
            titulo = copy.titulo;
            cartel = copy.cartel;
            year = copy.year;
            genero = copy.genero;
            calificacion = copy.calificacion;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
