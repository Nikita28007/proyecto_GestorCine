using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_GestorCine
{
    class Sesion : INotifyPropertyChanged
    {
        

        public int? pelicula { get; set; }
        public string hora { get; set; }
        public int? sala { get; set; }


        public Sesion()
        {

            pelicula = null;
            hora = "";
            sala = null;
        }

        public Sesion(int titulo, string hora, int sala)
        {
          
            this.pelicula = titulo;
            this.hora = hora;
            this.sala = sala;
        }
        public Sesion(Sesion sesion) 
        {

            pelicula = sesion.pelicula;
            hora = sesion.hora;
            sala = sesion.sala;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
