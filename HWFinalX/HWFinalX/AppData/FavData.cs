using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace HWFinalX.AppData
{
    class FavData
    {
        private static readonly FavData Instance = new FavData();

        public Dictionary<string, List<SharpEntity>> Entities = new Dictionary<string, List<SharpEntity>>();

        public List<Movie> Movies { get; set; }
        public List<Character> Characters { get; set; }
        public List<Planet> Planets { get; set; }
        public List<Specie> Species { get; set; }
        public List<Starship> Starships { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        private FavData()
        {
            Entities.Add("Movies", new List<SharpEntity>());
            Entities.Add("Characters", new List<SharpEntity>());
            Entities.Add("Planets", new List<SharpEntity>());
            Entities.Add("Species", new List<SharpEntity>());
            Entities.Add("Starships", new List<SharpEntity>());
            Entities.Add("Vehicles", new List<SharpEntity>());
        }

        public static FavData GetInstance()
        {
            return Instance;
        }
    }
}
