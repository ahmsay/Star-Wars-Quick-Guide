namespace Entities
{
    public class Movie : SharpEntity
    {
        public string episode_id
        {
            get;
            set;
        }

        public string director
        {
            get;
            set;
        }

        public string producer
        {
            get;
            set;
        }

        public string opening_crawl
        {
            get;
            set;
        }

        public string release_date
        {
            get;
            set;
        }

        public override string[] displaynames
        {
            get { return new string[] { "Episode", "Director", "Producer", "Opening Crawl", "Release Date" }; }
        }
    }
}