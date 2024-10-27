using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminplaner.Model.Enums;

namespace Terminplaner.Model.Entities
{
    public class User
    {
        // you must write here [key] if property name differs from "Id" or "UserId"
        public Guid Id { get; set; }
        public string Username { get; set; }

        // alternative to what happens in Context class in OnModelCreating method ->  [Column("Password")]
        public string? PasswordHash { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
