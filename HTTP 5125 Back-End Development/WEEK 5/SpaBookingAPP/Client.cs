namespace SpaClient.Models
{
    class Client
    {
        public int id;
        public string name;
        public string email;
        public int phone_number;
        public bool gender;
        // Constructor
        public Client(int id_, string name_, string email_, int phone_number_, bool gender_)
        {
            id = id_;
            name = name_;
            email = email_;
            phone_number = phone_number_;
            gender = gender_;
        }

    }
}