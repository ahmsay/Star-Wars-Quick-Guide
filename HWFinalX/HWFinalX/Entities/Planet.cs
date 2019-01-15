namespace Entities
{
    public class Planet : SharpEntity
    {
        public string rotation_period
        {
            get;
            set;
        }

        public string orbital_period
        {
            get;
            set;
        }

        public string gravity
        {
            get;
            set;
        }

        public string terrain
        {
            get;
            set;
        }

        public string climate
        {
            get;
            set;
        }

        public string diameter
        {
            get;
            set;
        }

        public string surface_water
        {
            get;
            set;
        }

        public string population
        {
            get;
            set;
        }

        public override string[] displaynames
        {
            get { return new string[] { "Rotation Period (hour)", "Orbital Period (day)", "Gravity", "Terrain", "Climate", "Diameter (km)", "Surface Water", "Population" }; }
        }
    }
}