using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_GestorCine
{
    
    class BaseDeDatos
    {
      
        private readonly SqliteConnection _conexion;
        private SqliteCommand _comando;

        public BaseDeDatos()
        {
            _conexion = new SqliteConnection("Data Source=peliculas.db");
            CrearTablas();
            InsertarDatos();
        }


        private void InsertarDatos()
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "DELETE FROM personas";
            _comando.ExecuteNonQuery();
            _comando.CommandText = "INSERT INTO personas VALUES ('Ana',30)";
            _comando.ExecuteNonQuery();
            _comando.CommandText = "INSERT INTO personas VALUES ('Pedro',25)";
            _comando.ExecuteNonQuery();
            _comando.CommandText = "INSERT INTO personas VALUES ('Clara',28)";
            _comando.ExecuteNonQuery();
            _comando.CommandText = "INSERT INTO personas VALUES ('Juan',19)";
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }
        //int? id, string titulo, string cartel, int? year, string genero, string calificacion
        private void CrearTablas()
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = @"CREATE TABLE peliculas (idPelicula INTEGER PRIMARY KEY,titulo TEXT,cartel TEXT,año INTEGER,genero TEXT,calificacion TEXT);";
            _comando.CommandText = @"CREATE TABLE salas (idSala INTEGER PRIMARY KEY AUTOINCREMENT,numero TEXT,capacidad INTEGER,disponible BOOLEAN DEFAULT (true));";
            _comando.CommandText = @"CREATE TABLE sesiones (idSesion INTEGER PRIMARY KEY AUTOINCREMENT,pelicula INTEGER REFERENCES peliculas (idPelicula),sala INTEGER REFERENCES salas (idSala),hora TEXT);";
            _comando.CommandText = @"CREATE TABLE ventas (idVenta INTEGER PRIMARY KEY AUTOINCREMENT,sesion INTEGER REFERENCES sesiones (idSesion),cantidad INTEGER,pago TEXT);";

            _comando.ExecuteNonQuery();

            _conexion.Close();
        }


        public void Insertar(Sesion sesion)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "INSERT INTO sesiones VALUES (@pelicula,@sala,@hora)";
            _comando.Parameters.Add("@pelicula", SqliteType.Integer);
            _comando.Parameters.Add("@sala", SqliteType.Integer);
            _comando.Parameters.Add("@hora", SqliteType.Text);
            _comando.Parameters["@pelicula"].Value = sesion;
            _comando.Parameters["@sala"].Value = sesion.sala;
            _comando.Parameters["@hora"].Value = sesion.hora;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        public void Actualizar(Sesion sesion)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "UPDATE sesiones SET pelicula=@pelicula,sala=@sala,hora=@hora WHERE idSesion=@idSesion";
            _comando.Parameters.Add("@pelicula", SqliteType.Integer);
            _comando.Parameters.Add("@sala", SqliteType.Integer);
            _comando.Parameters.Add("@hora", SqliteType.Text);
            _comando.Parameters["@pelicula"].Value = sesion.titulo;
            _comando.Parameters["@sala"].Value = sesion.sala;
            _comando.Parameters["@hora"].Value = sesion.hora;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        public void Delete(Sesion sesion)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "DELETE FROM sesiones WHERE idSesion=@id";
            _comando.Parameters.Add("@id", SqliteType.Integer);
            _comando.Parameters["@id"].Value = sesion;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

    }


}
