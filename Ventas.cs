using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_GestorCine
{
    class Ventas
    {
        public int? id { get; set; }
        public int? sesion { get; set; }
        public Sesion idSesion { get; set; }
        public int? cantidad { get; set; }
        public string pago { get; set; }

        public Ventas()
        {
            id = null;
            sesion = null;
            idSesion = null;
            cantidad = null;
            pago ="";
        }

        public Ventas(int id, int sesion, Sesion idSesion, int cantidad, string pago)
        {
            this.id = id;
            this.sesion = sesion;
            this.idSesion = idSesion;
            this.cantidad = cantidad;
            this.pago = pago;
       
        }

        public Ventas(Ventas ventas) 
        {
            id = ventas.id;
            sesion = ventas.sesion;
            idSesion = ventas.idSesion;
            cantidad = ventas.cantidad;
            pago = ventas.pago;

        }


    }
}
