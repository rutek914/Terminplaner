using Terminplaner.Model.Enums;

namespace Terminplaner.Model.Entities {
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string? PasswordHash { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
