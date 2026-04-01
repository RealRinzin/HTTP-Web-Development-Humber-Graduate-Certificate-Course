namespace tvShowPetProject.Models;

public class Shows
{
    // public double Score { get; set; }
    // public Show Show { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public string language { get; set; }

    public List<string> genres { get; set; }
    // public string status { get; set; }
    // public int runtime { get; set; }
    // public string premiered { get; set; }
    // public string officialSite { get; set; }
    // public string schedule { get; set; }
    // public string rating { get; set; }
    // public string weight { get; set; }
}

public class Show
{
    public int id { get; set; }
    public string name { get; set; }
    public string url { get; set; }
}
