using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace practical_07.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Please enter your email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter the subject.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please select a rating.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Please enter your comments.")]
        [StringLength(500, ErrorMessage = "Comments cannot exceed 500 characters.")]
        public string Comments { get; set; }

        public DateTime SubmittedAt { get; set; }
    }
}