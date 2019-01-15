using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace HWFinalX.AppData
{
    class Data
    {
        private static readonly Data Instance = new Data();

        public Dictionary<string, List<SharpEntity>> Entities = new Dictionary<string, List<SharpEntity>>();

        public List<Quote> Quotes { get; set; }
        public List<Movie> Movies { get; set; }
        public List<Character> Characters { get; set; }
        public List<Planet> Planets { get; set; }
        public List<Specie> Species { get; set; }
        public List<Starship> Starships { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<SharpEntity> Favorites { get; set; }

        private Data()
        {
            Quotes = new List<Quote>();
            Entities.Add("Movies", new List<SharpEntity>());
            Entities.Add("Characters", new List<SharpEntity>());
            Entities.Add("Planets", new List<SharpEntity>());
            Entities.Add("Species", new List<SharpEntity>());
            Entities.Add("Starships", new List<SharpEntity>());
            Entities.Add("Vehicles", new List<SharpEntity>());
            Entities.Add("Favorites", new List<SharpEntity>());
        }

        public static Data GetInstance()
        {
            return Instance;
        }
    }
}
