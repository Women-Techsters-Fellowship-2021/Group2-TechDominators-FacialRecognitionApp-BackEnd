using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace FaceRecognition.Models
{
    public class Parent
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ParentPhoto { get; set; }
        public string ParentScannedPhoto { get; set; }
        public AppUser User { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public Student Student { get; set; }

        [ForeignKey("Student")]
        public string StudentId { get; set; }
    }
}