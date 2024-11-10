using Terminplaner.Model.Enums;

namespace Terminplaner.Model.Entities {
    /// <summary>
    /// 
    /// </summary>
    public class Appointment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public AppointmentStatus Status { get; set; }
        public User User { get; set; }

        // braucht man nicht wegen "shadow foreign key property" aber so ist es besser zu verstehen usw.
        public Guid UserId { get; set; }
    }
}
