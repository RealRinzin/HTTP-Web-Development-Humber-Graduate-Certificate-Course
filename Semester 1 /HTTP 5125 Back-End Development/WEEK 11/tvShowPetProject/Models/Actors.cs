namespace tvShowPetProject.Models
{
    public class Actors
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        // public date { get; set; }
        public string birtyday { get; set; }
        public string deathday { get; set; }
        public string gender { get; set; }
        public PeopleImage image { get; set; }
        public Country country { get; set; }

    }

    public class PeopleImage
    {
        public string medium { get; set; }
        public string original { get; set; }
    }

    public class Country
    {
        public string name { get; set; }
        public string code { get; set; }
        public string timezone { get; set; }
    }
}
