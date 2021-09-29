using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace FaceRecognition.Models
{
    public class Student
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Class { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string StudentPhoto { get; set; } // PhotoPath 
        public AppUser User { get; set; }

        [ForeignKey("User")]
        public string SchoolId { get; set; }
        public ICollection<Parent> Parents { get; set; }

    }
}