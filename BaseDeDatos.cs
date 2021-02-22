using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Diagnostics;

namespace proyecto_GestorCine
{

    class BaseDeDatos
    {
        string filePath = "";
        string path = Environment.CurrentDirectory + "\\DB";
        private readonly SqliteConnection _conexion;
        private SqliteCommand _comando;

        public BaseDeDatos()
        {
            CrearBaseDeDatos();
            string conection = string.Format("Data Source={0};", filePath);
            _conexion = new SqliteConnection(conection);

            //CrearTablas();
            // InsertarDatos();
        }

        private void CrearBaseDeDatos()
        {

            if (!string.IsNullOrEmpty(path) || !Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                filePath = path + "\\peliculas.db";

            }
            if (!File.Exists(filePath))
            {

                SQLiteConnection.CreateFile(filePath);

            }
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

            _comando.CommandText = @"CREATE TABLE IF NOT EXISTS peliculas (idPelicula INTEGER PRIMARY KEY,titulo TEXT,cartel TEXT,año INTEGER,genero TEXT,calificacion TEXT);";
            _comando.ExecuteNonQuery();
            _comando.CommandText = @"CREATE TABLE IF NOT EXISTS salas (idSala INTEGER PRIMARY KEY AUTOINCREMENT,numero TEXT,capacidad INTEGER,disponible BOOLEAN DEFAULT (true));";
            _comando.ExecuteNonQuery();
            _comando.CommandText = @"CREATE TABLE IF NOT EXISTS sesiones (idSesion INTEGER PRIMARY KEY AUTOINCREMENT,pelicula INTEGER REFERENCES peliculas (idPelicula),sala INTEGER REFERENCES salas (idSala),hora TEXT);";
            _comando.ExecuteNonQuery();
            _comando.CommandText = @"CREATE TABLE IF NOT EXISTS ventas (idVenta INTEGER PRIMARY KEY AUTOINCREMENT,sesion INTEGER REFERENCES sesiones (idSesion),cantidad INTEGER,pago TEXT);";


            _conexion.Close();
        }


        public void InsertarSesion(Sesion sesion)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "INSERT INTO sesiones VALUES (null,@pelicula,@sala,@hora)";
            _comando.Parameters.Add("@pelicula", SqliteType.Integer);
            _comando.Parameters.Add("@sala", SqliteType.Integer);
            _comando.Parameters.Add("@hora", SqliteType.Text);
            _comando.Parameters["@pelicula"].Value = sesion.pelicula;
            _comando.Parameters["@sala"].Value = sesion.sala;
            _comando.Parameters["@hora"].Value = sesion.hora;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        public void InsertarPelicula(Peliculas pelicula)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "INSERT INTO peliculas VALUES (@idPelicula,@titulo,@cartel,@año,@genero,@calificacion)";
            _comando.Parameters.Add("@idPelicula", SqliteType.Integer);
            _comando.Parameters.Add("@titulo", SqliteType.Text);
            _comando.Parameters.Add("@cartel", SqliteType.Text);
            _comando.Parameters.Add("@año", SqliteType.Integer);
            _comando.Parameters.Add("@genero", SqliteType.Text);
            _comando.Parameters.Add("@calificacion", SqliteType.Text);
            _comando.Parameters["@idPelicula"].Value = pelicula.id;
            _comando.Parameters["@titulo"].Value = pelicula.titulo;
            _comando.Parameters["@cartel"].Value = pelicula.cartel;
            _comando.Parameters["@año"].Value = pelicula.year;
            _comando.Parameters["@genero"].Value = pelicula.genero;
            _comando.Parameters["@calificacion"].Value = pelicula.calificacion;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        public void InsertarVentas(Ventas ventas)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "INSERT INTO ventas VALUES (null,@sesion,@cantidad,@pago)";
            _comando.Parameters.Add("@sesion", SqliteType.Text);
            _comando.Parameters.Add("@cantidad", SqliteType.Integer);
            _comando.Parameters.Add("@pago", SqliteType.Text);

            _comando.Parameters["@sesion"].Value = ventas.sesion;
            _comando.Parameters["@cantidad"].Value = ventas.cantidad;
            _comando.Parameters["@pago"].Value = ventas.pago;

            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        public ObservableCollection<Peliculas> ObtenerPeliculas()
        {
            ObservableCollection<Peliculas> resultado = new ObservableCollection<Peliculas>();

            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "SELECT * FROM peliculas";
            SqliteDataReader lector = _comando.ExecuteReader();

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int id = lector.GetInt32(0);
                    string titulo = lector.GetString(1);
                    string cartel = lector.GetString(2);
                    int anyo = lector.GetInt32(3);
                    string genero = lector.GetString(4);
                    string calificacion = lector.GetString(5);

                    resultado.Add(new Peliculas(id, titulo, cartel, anyo, genero, calificacion));
                }
            }

            lector.Close();
            _conexion.Close();

            return resultado;

        }

        public void Actualizar(Sesion sesion)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "UPDATE sesiones SET pelicula=@pelicula,sala=@sala,hora=@hora WHERE idSesion=@idSesion";
            _comando.Parameters.Add("@pelicula", SqliteType.Integer);
            _comando.Parameters.Add("@sala", SqliteType.Integer);
            _comando.Parameters.Add("@hora", SqliteType.Text);
            _comando.Parameters["@pelicula"].Value = sesion.pelicula;
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
