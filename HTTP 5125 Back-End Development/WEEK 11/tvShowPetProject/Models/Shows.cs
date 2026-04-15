namespace tvShowPetProject.Models;

public class Shows
{
    // public double Score { get; set; }
    // public Show Show { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public string language { get; set; }

    public string url { get; set; }
    public string summary { get; set; }
    public string premiered {get;set;}
    public List<string> genres { get; set; }
    public Image image { get; set; }

    // public Rating rating {get; set;}


}

/** The Show class represents a TV show with its ID, name, and URL. */
public class Show
{
    public int id { get; set; }
    public string name { get; set; }
    public string url { get; set; }
}

/*** The Image class represents the image information for a TV show, including the medium and original image URLs. */
public class Image
{
    public string medium { get; set; }
    public string original { get; set; }
}


public class Rating
{
    public int average;
}