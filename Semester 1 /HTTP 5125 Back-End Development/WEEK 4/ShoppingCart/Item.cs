namespace Shopping.Models
{
    class Item
    {
        public string name;
        public float price;
        public string description;

        public Item(string name_, float price_, string description_)
        {
            name = name_;
            price = price_;
            description = description_;
        }
// changes
        // public Item(string name_)
        // {
        //     name = name_;
        //     price = 90.3f;
        //     description = "Nothing";
        // }
    }
}
