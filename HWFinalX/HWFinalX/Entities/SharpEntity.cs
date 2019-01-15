namespace Entities
{
    public abstract class SharpEntity
    {
        public string name { get; set; }
        public string img_url { get; set; }
        public abstract string[] displaynames { get; }
    }
}