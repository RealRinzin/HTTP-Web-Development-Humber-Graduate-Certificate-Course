using BookingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Services;

public class AppointmentService
{
    private readonly AppDbContext _context;

    public AppointmentService(AppDbContext context)
    {
        _context = context;
    }

    public List<Appointment> GetAppointments()
    {
        return _context.Appointments
            .Include(a => a.Client)
            .Include(a => a.Service)
            .ToList();
    }

    public Appointment? getTheAppointment(int id)
    {
        return _context.Appointments.Find(id);
    }

    public void AddAppointment(Appointment appointment)
    {
        // 1. Ensure the Date property bound from form input is explicitly set to UTC
        appointment.Date = DateTime.SpecifyKind(appointment.Date.Date, DateTimeKind.Utc);

        // 2. Combine Date and Time into StartDateTime and mark as UTC
        DateTime localStart = appointment.Date.Date + appointment.Time;
        appointment.StartDateTime = DateTime.SpecifyKind(localStart, DateTimeKind.Utc);

        // 3. Mark UpdatedAt as UtcNow
        appointment.UpdatedAt = DateTime.UtcNow;

        _context.Appointments.Add(appointment);
        _context.SaveChanges();
    }

    public void UpdateAppointment(Appointment appointment)
    {
        // 1. Ensure the Date property bound from form input is explicitly set to UTC
        appointment.Date = DateTime.SpecifyKind(appointment.Date.Date, DateTimeKind.Utc);

        // 2. Combine Date and Time into StartDateTime and mark as UTC
        DateTime localStart = appointment.Date.Date + appointment.Time;
        appointment.StartDateTime = DateTime.SpecifyKind(localStart, DateTimeKind.Utc);

        _context.Appointments.Update(appointment);
        _context.SaveChanges();
    }

    public void DeleteAppointment(int id)
    {
        var appointment = _context.Appointments.Find(id);
        if (appointment == null) return;
        _context.Appointments.Remove(appointment);
        _context.SaveChanges();
    }

    public string? ValidateAppointment(Appointment appointment)
    {
        // 1. Check if date/time is in the past
        DateTime combinedStart = appointment.Date.Date + appointment.Time;
        if (combinedStart < DateTime.Now)
        {
            return "Appointment date and time cannot be in the past.";
        }

        // 2. Business Hours Check (9 AM - 5 PM)
        TimeSpan openingTime = new TimeSpan(9, 0, 0);
        TimeSpan closingTime = new TimeSpan(17, 0, 0);

        var service = _context.Services.Find(appointment.ServiceId);
        if (service == null) return "Invalid service selected.";

        TimeSpan duration = TimeSpan.FromHours(service.Duration);
        TimeSpan endAppointmentTime = appointment.Time + duration;

        if (appointment.Time < openingTime || endAppointmentTime > closingTime)
        {
            return "Appointment must be within business hours (9:00 AM to 5:00 PM).";
        }

        // 3. Overlap Check
        DateTime targetDateUtc = DateTime.SpecifyKind(appointment.Date.Date, DateTimeKind.Utc);

        var existingAppointments = _context.Appointments
            .Include(a => a.Service)
            .Where(a => a.Id != appointment.Id && a.StartDateTime.Date == targetDateUtc)
            .ToList();

        foreach (var existing in existingAppointments)
        {
            TimeSpan existingStart = existing.Time;
            TimeSpan existingEnd = existing.Time + TimeSpan.FromHours(existing.Service.Duration);

            if (appointment.Time < existingEnd && endAppointmentTime > existingStart)
            {
                return "This appointment time overlaps with an existing appointment.";
            }
        }

        return null;
    }
}