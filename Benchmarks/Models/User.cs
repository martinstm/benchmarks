using System;

namespace Benchmarks.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }

        public int ExperienceYears { get; set; }

        public User() 
        { }

        public User(string name, string email, int experienceYears = 1)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Active = true;
            ExperienceYears = experienceYears;
            CreationDate = DateTime.UtcNow;
        }
    }
}
