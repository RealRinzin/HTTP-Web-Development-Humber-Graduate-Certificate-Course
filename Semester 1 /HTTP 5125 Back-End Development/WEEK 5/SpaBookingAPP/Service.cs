namespace SpaService.Models
{
    class Service
    {
        public int id;
        public string name;
        public int price;
        // Constructor
        public Service(int id_, string name_, int price_)
        {
            id = id_;
            name = name_;
            price = price_;
        }

    }
}