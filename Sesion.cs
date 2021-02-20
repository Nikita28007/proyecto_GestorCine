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
      public  string foto { get; set; }
        public string titulo { get; set; }
        public string hora { get; set; }
        public string sala { get; set; }


        public Sesion()
        {
            foto = "";
            titulo ="";
            hora = "";
            sala = "";
        }

        public Sesion(string foto,string titulo, string hora, string sala)
        {
            this.foto = foto;
            this.titulo = titulo;
            this.hora = hora;
            this.sala = sala;
        }
        public Sesion(Sesion sesion) 
        {
            foto = sesion.foto;
            titulo = sesion.titulo;
            hora = sesion.hora;
            sala = sesion.sala;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
