namespace Entities
{
    public class Specie : SharpEntity
    {
        public string eye_colors
        {
            get;
            set;
        }

        public string skin_colors
        {
            get;
            set;
        }

        public string classification
        {
            get;
            set;
        }

        public string designation
        {
            get;
            set;
        }

        public string average_height
        {
            get;
            set;
        }

        public string average_lifespan
        {
            get;
            set;
        }

        public string hair_colors
        {
            get;
            set;
        }

        public string language
        {
            get;
            set;
        }

        public override string[] displaynames
        {
            get { return new string[] { "Eye Colors", "Skin Colors", "Classification", "Designation", "Average Height (cm)", "Average Lifespan", "Hair Colors", "Language" }; }
        }
    }
}