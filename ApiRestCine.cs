﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_GestorCine
{
    class ApiRestCine
    {
        public ObservableCollection<Peliculas> obtenerTodasPeliculas()
        {

            var client = new RestClient(Properties.Settings.Default.apiEndPoint);
            var request = new RestRequest(Method.GET); 
            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<ObservableCollection<Peliculas>>(response.Content);

        }




    }

    public class SessionResponse
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

    }
}
