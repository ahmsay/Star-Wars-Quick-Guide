﻿namespace Entities
{
    public class Starship : SharpEntity
    {
        public string model
        {
            get;
            set;
        }

        public string vehicle_class
        {
            get;
            set;
        }

        public string manufacturer
        {
            get;
            set;
        }

        public string length
        {
            get;
            set;
        }

        public string crew
        {
            get;
            set;
        }

        public string passengers
        {
            get;
            set;
        }

        public string consumables
        {
            get;
            set;
        }

        public string cargo_capacity
        {
            get;
            set;
        }

        public string max_atmosphering_speed
        {
            get;
            set;
        }

        public string hyperdrive_rating
        {
            get;
            set;
        }

        public string MGLT
        {
            get;
            set;
        }

        public string cost_in_credits
        {
            get;
            set;
        }

        public override string[] displaynames
        {
            get { return new string[] { "Model", "Class", "Manufacturer", "Length (m)", "Crew", "Passengers", "Consumables", "Cargo Capacity (kg)", "Max Atmosphering Speed (km)", "Hyperdrive Rating", "MGLT", "Cost (credits)" }; }
        }
    }
}