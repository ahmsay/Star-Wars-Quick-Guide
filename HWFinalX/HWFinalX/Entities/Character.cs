namespace Entities
{
    public class Character : SharpEntity
    {
        public string birthYear
        {
            get;
            set;
        }

        public string height
        {
            get;
            set;
        }

        public string mass
        {
            get;
            set;
        }

        public string gender
        {
            get;
            set;
        }

        public string eyeColor
        {
            get;
            set;
        }

        public string hairColor
        {
            get;
            set;
        }

        public string skinColor
        {
            get;
            set;
        }

        public override string[] displaynames
        {
            get { return new string[] { "Birth Year", "Height (cm)", "Mass (kg)", "Gender", "Eye Color", "Hair Color", "Skin Color" }; }
        }
    }
}