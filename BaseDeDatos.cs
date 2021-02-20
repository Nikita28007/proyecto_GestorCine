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

            _comando.CommandText = @"CREATE TABLE IF NOT EXISTS peliculas (
                                    id integer primary key,titulo varchar(100),cartel varchar(255),year)";
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

    }


}
