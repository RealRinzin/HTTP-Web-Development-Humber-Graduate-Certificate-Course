namespace SpaBookingSystem.Models 
// Appointment class to represent an appointment in the spa booking system

{
    public class Appointment
    {
        public Client Client { get; set; }
        public Service Service { get; set; }
        public DateTime AppointmentDate { get; set; }

        public Appointment(Client client, Service service, DateTime appointmentDate)
        {
            Client = client;
            Service = service;
            AppointmentDate = appointmentDate;
        }

    }
}
